import { default as iView } from './IndexView.js';
import { users, model } from './Model.js';
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
  // Hallgatók kilistázása
  iView.printUsers(users);

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
  console.log(users);

  const controlLogIn = function (username, pw) {
    console.log('Login');
    validateUser(username, pw);
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
    const foundUser = findUser(username, pw);
    if (!foundUser) return alert('Nincs ilyen hallgató!');

    localStorage.setItem('user', JSON.stringify({ username, pw }));
    window.location.href = "index.html";
  }
};

const findUser = function (username, pw) {
  const user = users.find(
    user => user.username === username && user.password === pw
  );
  return user;
};
