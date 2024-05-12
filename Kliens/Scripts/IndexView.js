class IndexView {
  

  addHandlerFilterCourses(handler) {
    document.querySelector('#filter').addEventListener('change', function(e) {
      handler(e.target.value);
    })
  }

  addHandlerToggleCourses(handler) {
    document.querySelectorAll('#coursesBtn').forEach(btn => {
      btn.addEventListener('click', function(e) {
        document.querySelector('#filter').value = 0;
        e.target.innerText == 'Összes kurzus' ? e.target.nextElementSibling.disabled = false : e.target.previousElementSibling.disabled = false;
        e.target.disabled = true;
        handler(e.target.innerText);
      })
    })
  }

  addHandlerLogOut(handler) {
    document.querySelector('.btn--logout').addEventListener('click', handler);
  }

  printCourses(courses) {
    // Kurzusok listázása
    let d = document.querySelector('.courses');
    d.innerHTML='';
    for (const course of courses) {
      let courseHTML = `
        <div class="course ${course?.enrolled ? 'course--enrolled' : ''}">
          Kód: ${course.code}<br>
          ${course.name} <br>
          ${course.credit} kredit <br>
          <div class="d-flex position-relative justify-content-end">
            ${!course?.enrolled ? `
            <button class="position-absolute start-0 top-0">
              Feliratkozás
            </button>
            ` : ''}
            <button data-bs-toggle="collapse" data-bs-target="#collapse-${course.code}" aria-expanded="false" aria-controls="collapse-${course.code}">
              Megtekint
            </button>
          </div>
          <div class="collapse" id="collapse-${course.code}">
            Hallgatók listája
          </div>
        </div>
      `;
      d.insertAdjacentHTML('beforeend', courseHTML);
    }
  }

  printDegrees(degrees) {
    // Szakok kiírása a menühöz
    let selectFilter = document.querySelector('#filter');
    for(const degree of degrees) {
      let degreeHTML = `<option value="${degree.id}">${degree.name}</option>`;
      selectFilter.insertAdjacentHTML('beforeend', degreeHTML);
    }
    
  }

  showLoggedInUser(user) {
    document.querySelector('#loggedInUser').textContent = `${user.name} (${user.userName})`;
  }

}

export default new IndexView();
