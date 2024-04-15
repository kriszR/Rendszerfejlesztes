'use strict';

class Login {
  constructor() {}

  validateUser() {
    let username = document.querySelector("#username").value;
    let pw = document.querySelector("#userpw").value;

    if (!username || !pw) {
      alert("Felhasználónév és jelszó megadása kötelező!");
    } else {
      localStorage.setItem('username', username);
      window.location.href = "index.html";
    }
  }
}

let login = new Login();
