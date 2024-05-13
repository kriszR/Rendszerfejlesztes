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
  } catch (err) {
    alert(err);
  }

  iView.printCourses(state.allCourses);

  iView.showLoggedInUser(state.loggedInUser);

  iView.printDegrees(state.degrees);

  iView.printCreateEvent();
  if (state.loggedInUser.isAdmin) {
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
      iView.printCourses(state.myCourses);
      state.isAllCourseOpen = false;
    }
  };

  const controlFilterCourses = function (value) {
    const coursesToFilter = state.isAllCourseOpen
      ? state.allCourses
      : state.myCourses;
    const filteredCourses = coursesToFilter.filter(course =>
      course.degreeIds.includes(+value)
    );
    if (+value == 0) iView.printCourses(coursesToFilter);
    else iView.printCourses(filteredCourses);
  };

  const controlCreateEvent = function (data) {
    try {
      model.postData('Events/CreateEvent', data, true);
      alert("Esemény sikeresen létrehozva!");
    } catch (err) {
      alert(err);
    }
  };

  const init = function () {
    iView.addHandlerLogOut(controlLogOut);
    iView.addHandlerToggleCourses(controlShowCourses);
    iView.addHandlerFilterCourses(controlFilterCourses);
    iView.addHandlerCreateEvent(controlCreateEvent);
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
