"use strict";

//import { ContentHandler } from "./ContentHandler";

let defaultURL = "https://localhost:7089/api/";

class FetchAPI {
  constructor() {}

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

  postStudent() {
    try {
      let inputs = document.querySelectorAll("input");
      const data = {
        id: 0,
        firstName: inputs[0].value,
        lastName: inputs[1].value,
        neptunCode: inputs[2].value,
        email: inputs[3].value,
        password: inputs[4].value,
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
        return student.email == localStorage.getItem("email");
      });
      document.querySelector("#loggedInStudent").textContent = loggedInStudent
        ? loggedInStudent.firstName + " " + loggedInStudent.lastName
        : "...(nem tárolt hallgató)";

    // Hallgatók listázása
    let d = document.querySelector(".courses");
    for (const student of students) {
      let c = document.createElement("div");
      let x = document.createElement("span");
      c.innerHTML = `Név: ${student.firstName} ${student.lastName}, Neptun kód: ${student.neptunCode}, Email: ${student.email} `;
      x.innerHTML = "&#10005";
      x.classList.add("del");
      x.onclick = () => this.deleteData(student.id);
      c.classList.add("course");
      c.appendChild(x);
      d.appendChild(c);
    }
  }

  logOut() {
    localStorage.clear();
    window.location.href = "login.html";
  }
}

let fetchAPI = new FetchAPI();
fetchAPI.getData("Students");
