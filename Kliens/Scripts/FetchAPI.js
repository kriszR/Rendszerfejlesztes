"use strict";


let defaultURL = "https://localhost:7089/api/";

class FetchAPI {
  constructor() {
    this._checkLogin();
  }

  async deleteData(id) {
    try {
      const response = await fetch(defaultURL + "Students/" + id, {
        method: "DELETE",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
          "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
        //body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error("Failed to fetch");
      }
    } catch (error) {
      console.error("Error:", error);
    }
  }

  async postData(slug = "", data = {}) {
    try {
      const response = await fetch(defaultURL + slug, {
        method: "POST",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
          "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error("Failed to fetch");
      }
    } catch (error) {
      console.error("Error:", error);
    }
  }

  createStudentData() {
    try {
      let inputs = document.querySelectorAll("input");
      const data = {
        id: 0,
        username: inputs[0].value,
        name: inputs[1].value,
        password: inputs[2].value,
      };
      this.postData("Students", data);
    } catch (error) {
      console.error(error);
    }
  }

  async getData(slug = "") {
    try {
      const response = await fetch(defaultURL + slug, {
        method: "GET",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
          "Content-Type": "application/json",
        },
        redirect: "follow",
        referrerPolicy: "no-referrer",
      });

      if (!response.ok) {
        throw new Error("Failed to fetch");
      }

      this.printJsonContent(response.json());
    } catch (error) {
      console.error("Error:", error);
    }
  }

  async printJsonContent(response) {
    let students = await response;
    

    // Bejelentkezett hallgató megkeresése
      const loggedInStudent = students.find((student) => {
        return student.username == localStorage.getItem("username");
      });
      document.querySelector("#loggedInStudent").textContent = loggedInStudent
        ? loggedInStudent.name
        : "...(nem tárolt hallgató)";


    // Tárgyak listázása
    let d = document.querySelector(".courses");
    for (const student of students) {
      let studentHTML = `
        <div class="course">${student.name} (${student.username}) <span class="del" onClick="${()=>this.deleteData(student.id)}">&#10005</span><br>
        Kurzusai:${student.myCourses.join(',')}<br>
        Jegyei: ${student.degrees.join(',')}
        </div>
      `;
      d.insertAdjacentHTML('beforeend', studentHTML);
      console.log(student.myCourses);

    }
  }

  logOut() {
    localStorage.clear();
    window.location.href = "login.html";
  }

  _checkLogin() {
    if(!localStorage.getItem('username')) {
      console.log('Nincs bejelentkezve');
      window.location.href ='login.html';
    }
  }
}

let fetchAPI = new FetchAPI();
fetchAPI.getData("Students");
