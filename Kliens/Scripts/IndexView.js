class IndexView {
  
  addHandlerEnrollCourse(handler) {
    document.querySelectorAll('.enrollBtn').forEach(btn => btn.addEventListener('click', handler));
  }
  
  addHandlerCreateEvent(handler) {
    document.querySelector('.create-event')?.addEventListener('click', function() {
      let courseId = +document.querySelector('#eventCourseID').value;
      let name = document.querySelector('#eventName').value;
      let description = document.querySelector('#eventDesc').value;
      if(courseId && name && description)
        handler({courseId, name, description});
      else {
        alert('Nem lehet üresen mező esemény létrehozásakor vagy a kurzus id csak szám lehet!');
        return;
      }
    });
  }

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

  printCourses(courses, events) {
    // Kurzusok listázása
    let d = document.querySelector('.courses');
    d.innerHTML='';
    for (const course of courses) {
      let courseHTML = `
      
      <div class="course ${course?.enrolled ? 'course--enrolled' : ''}">
      ${events ? this._printEvent(course.id, events) : ''}
          Kód: ${course.code}<br>
          ${course.name} <br>
          ${course.credit} kredit <br>
          <div class="d-flex position-relative justify-content-end">
            ${!course?.enrolled ? `
            <button class="enrollBtn position-absolute start-0 top-0" data-courseId="${course.id}">
              Feliratkozás
            </button>
            ` : ''}
            <button data-bs-toggle="collapse" data-bs-target="#collapse-${course.code}" aria-expanded="false" aria-controls="collapse-${course.code}">
              Megtekint
            </button>
          </div>
          <div class="collapse" id="collapse-${course.code}">
            Hallgatók listája, akik felvették a tárgyat: </br>
            ${Array.from(course.enrolledUsers).join('</br>')}
          </div>
        </div>
      `;
      d.insertAdjacentHTML('beforeend', courseHTML);
    }
    
  }
  _printEvent(id, events) {
    let html='';
    events.forEach(event => {
      if(event.courseId == id)
        html+=`<p class="text-start bg-light rounded-pill p-3">
        Esemény neve: ${event.name} <br/>
        Leírása: ${event.description} </p>
      `;
    })
    return html;
  }

  printCreateEvent() {
    let eventHTML = `
      <div class="event bg-secondary p-4 h-50 border border-dark">
        <h2 class="text-white">Esemény létrehozása</h2>
        <div class="form-floating mb-3">
          <input type="text" class="form-control" id="eventCourseID" placeholder="1">
          <label for="floatingInputID">Eseményhez tartozó kurzus ID</label>
        </div>
        <div class="form-floating mb-3">
          <input type="text" class="form-control" id="eventName" placeholder="Valami">
          <label for="eventName">Esemény neve</label>
        </div>
        <div class="form-floating mb-3">
          <input type="text" class="form-control" id="eventDesc" placeholder="Lesz egy valami">
          <label for="eventDesc">Esemény leírása</label>
        </div>
        <button class="create-event">Létrehozás</button>
      </div>
    `;
    document.querySelector('.main').insertAdjacentHTML('beforeend', eventHTML);
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
