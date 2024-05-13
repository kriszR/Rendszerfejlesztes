import { default as iView } from './IndexView.js';
import { state, model } from './Model.js';
import LoginView from './LoginView.js';
import * as helper from './Helper.js';
import { webSocket } from './WebSocket.js';

if (window.location.pathname === '/') window.location.replace('login.html');

// Ha a főoldalon vagyunk
if (window.location.pathname === '/index.html') {
  helper.checkLogin();
  try {
    await model.getUsers('Users');
    model.findUser();
    await model.getAllCourses(`Courses`);
    await model.getMyCourses('Mycourses');
    await model.getDegrees('Degrees');
    await model.getApprovedDegress('ApprovedDegrees');
    await model.getEvents('Events')
  } catch (err) {
    alert(err);
  }

  iView.printCourses(state.allCourses);

  iView.showLoggedInUser(state.loggedInUser);

  iView.printDegrees(state.degrees);

  if (state.loggedInUser.isAdmin) {
    iView.printCreateEvent();
  }

  const controlLogOut = function () {
    localStorage.clear();
    window.location.replace('login.html');
  };

  const controlShowCourses = function (str) {
    if (str === 'Összes kurzus') {
      iView.printCourses(state.allCourses);
      state.isAllCourseOpen = true;
    } else {
      iView.printCourses(state.myCourses, state.events);
      state.isAllCourseOpen = false;
    }
    iView.addHandlerEnrollCourse(controlEnrollCourse);
  };

  const controlFilterCourses = function (value) {
    const coursesToFilter = state.isAllCourseOpen
      ? state.allCourses
      : state.myCourses;
    const ev = state.isAllCourseOpen ? null : state.events;
    const filteredCourses = coursesToFilter.filter(course =>
      course.degreeIds.includes(+value)
    );
    if (+value == 0) iView.printCourses(coursesToFilter, ev);
    else iView.printCourses(filteredCourses, ev);
    iView.addHandlerEnrollCourse(controlEnrollCourse);
  };

  const controlCreateEvent = function (data) {
    try {
      model.postData('Events/CreateEvent', data, true);
      webSocket.sendMessage(data.description);
      location.reload();
    } catch (err) {
      alert(err);
    }
  };

  const controlEnrollCourse = async function(e) {
   await model.postData('Users/AddCourseToUser', {userId:+state.loggedInUser.id, courseId:+e.target.dataset.courseid},true).then(response => {
      if(response.success) {
        alert('Sikeres feliratkozás!');
        location.reload();
      } else {
        alert(response.message);
      }
    });

  }

  const init = function () {
    iView.addHandlerLogOut(controlLogOut);
    iView.addHandlerToggleCourses(controlShowCourses);
    iView.addHandlerFilterCourses(controlFilterCourses);
    iView.addHandlerCreateEvent(controlCreateEvent);
    iView.addHandlerEnrollCourse(controlEnrollCourse);
  };
  init();
}

// Ha a bejelentkezésnél vagyunk
if (window.location.pathname === '/login.html') {
  const controlLogIn = async function (username, pw) {
    if (!username || !pw) {
      alert('Felhasználónév és jelszó megadása kötelező!');
    } else {
      let user = {
        userName: username,
        password: pw,
      };
      await model.postData('Account/login', user, false).then(async user => {
        if (await user.token) {
          localStorage.setItem('user', JSON.stringify(user));
          window.location.replace('index.html');
        } else {
          alert('ERROR');
        }
      });
    }
  };

  const init = function () {
    LoginView.addHandlerLogIn(controlLogIn);
  };
  init();
}
