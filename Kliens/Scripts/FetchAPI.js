"use strict";

let defaultURL = "https://localhost:7089/api/";

class FetchAPI {
  constructor() {}

  async postData(slug = "", data = {}) {
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

      const students = await response.json();
      console.log(students);
    } catch (error) {
      console.error("Error:", error);
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

      return await response.json();
      //console.log(students);
    } catch (error) {
      console.error("Error:", error);
    }
  }

  async printJsonContent(response) {
    let students = await response;
    let d = document.querySelector(".courses");
    for (const student of students) {
      let c = document.createElement("div");
      c.innerHTML = `Név: ${student.firstName} ${student.lastName}, Neptun kód: ${student.neptunCode}, Email: ${student.email} `;
      c.classList.add("course");
      d.appendChild(c);
    }
    /*const [loggedInStudent] = Students.filter((student) => {
      return student.email == localStorage.getItem("email");
    });
    document.querySelector("#loggedInStudent").textContent =
      loggedInStudent.firstname + " " + loggedInStudent.lastname;
    let d = document.querySelector(".courses");
    for (const course of loggedInStudent.courses) {
      let c = document.createElement("div");
      c.innerHTML = course;
      c.classList.add("course");
      d.appendChild(c);
    }*/
  }

  logOut() {
    localStorage.clear();
    window.location.href = "login.html";
  }
}

let fetchAPI = new FetchAPI();
let response = fetchAPI.getData("Students");
fetchAPI.printJsonContent(response);
