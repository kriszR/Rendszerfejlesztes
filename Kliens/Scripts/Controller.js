import { default as iView } from './IndexView.js';
import { state, model } from './Model.js';
import LoginView from './LoginView.js';
import * as helper from './Helper.js';
 

try {
  // Hallgatók lekérése, ('users' a Model.js-ben van tárolva)
  await model.getUsers();
} catch (err) {
  console.error(err);
}

// Ha a főoldalon vagyunk
if (window.location.pathname == '/index.html') {
  
  model.findUser();
  await model.getUserCourses(`/${state.loggedInUser.id}/courses`);
  console.log(state.courses);
  // Kurzusok kilistázása
  iView.printCourses(state.courses);

  iView.showLoggedInUser(state.loggedInUser);




  const controlLogOut = function () {
    localStorage.clear();
    window.location.href = 'login.html';
  };

  const init = function () {
    iView.addHandlerLogOut(controlLogOut);
  };
  init();
}

// Ha a bejelentkezésnél vagyunk
if (window.location.pathname == '/login.html') {
  console.log(state.users);

  const controlLogIn = function (username, pw) {
    validateUser(username, pw);
    console.log('Login');
  };

  const init = function () {
    LoginView.addHandlerLogIn(controlLogIn);
  };
  init();
}

const validateUser = function (username, pw) {
  if (!username || !pw) {
    alert('Felhasználónév és jelszó megadása kötelező!');
  } else {

    model.findUser(username, pw);

    if (!state.loggedInUser) return alert('Nincs ilyen hallgató!');


    localStorage.setItem('user', JSON.stringify({ username, pw }));
    window.location.href = "index.html";
  }
};


