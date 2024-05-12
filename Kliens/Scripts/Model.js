let URL = 'https://localhost:7089/api/';

export const state = {
  users: [],
  allCourses: [],
  myCourses:[],
  events: [],
  degrees:[],
  loggedInUser: {},
  isAllCourseOpen: true,
};

class Model {

  async postData(slug = '', data = {}, needAuth = true) {
    
    const requestOptions = {
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
            'Content-Type': 'application/json',
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
        body: JSON.stringify(data),
    };

    if (needAuth) {
        const authToken = localStorage.getItem('data');
        if (authToken) {
            requestOptions.headers.Authorization = `Bearer ${JSON.parse(authToken).token}`;
        } else {
            throw new Error('Authentication token not found');
        }
    }

    try {
        const response = await fetch(URL + slug, requestOptions);
        if (response.status === 500) {
           alert('Nincs ilyen felhasználó!');
        }
        return await response.json();
    } catch (err) {
        throw err;
    }
}

  async getApprovedDegress(slug='', needAuth = true) {
    try {
      const response = await fetch(URL + slug, {
        method: 'GET',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json',
          Authorization: 'Bearer ' + (needAuth ? JSON.parse(localStorage.getItem('user')).token : null),
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
      });

      if (!response.ok) {
        throw new Error('Nem lehet lekérdezni a szak-kurzus-t');
      }
      console.log('szak-kurzus lefutott');
      let szak_kurzus = await response.json();
      state.allCourses.forEach(course => {
        course.degreeIds = [];
        for(const szak_k of szak_kurzus) {
          if(szak_k.courseId == course.id)
            course.degreeIds.push(szak_k.degreeId);
        }
      })
    } catch (error) {
      throw error;
    }
  }

  async getDegrees(slug='', needAuth = true) {
    try {
      const response = await fetch(URL + slug, {
        method: 'GET',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json',
          Authorization: 'Bearer ' + (needAuth ? JSON.parse(localStorage.getItem('user')).token : null),
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
      });

      if (!response.ok) {
        throw new Error('Nem lehet lekérdezni a szakokat');
      }
      console.log('degree lefutott');
      state.degrees = await response.json();
    } catch (error) {
      throw error;
    }
  }

  async getEvents(slug='', needAuth = true) {
    try {
      const response = await fetch(URL + slug, {
        method: 'GET',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json',
          Authorization: 'Bearer ' + (needAuth ? JSON.parse(localStorage.getItem('user')).token : null),
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
      });

      if (!response.ok) {
        throw new Error('Nem lehet lekérdezni az eseményeket');
      }
      console.log('events lefutott');
      state.events = await response.json();
    } catch (error) {
      throw error;
    }
  }

  async getUsers(slug = '', needAuth = true) {
    try {
      const response = await fetch(URL + slug, {
        method: 'GET',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json',
          Authorization: 'Bearer ' + (needAuth ? JSON.parse(localStorage.getItem('user')).token : null),
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
      });

      if (!response.ok) {
        throw new Error('Nem lehet lekérdezni a hallgatókat');
      }
      console.log('users lefutott');
      state.users = await response.json();
    } catch (error) {
      throw error;
    }
  }

  async getAllCourses(slug = '', needAuth = true) {
    try{
    const response = await fetch(URL + slug, {
      method: 'GET',
      mode: 'cors',
      cache: 'no-cache',
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + (needAuth ? JSON.parse(localStorage.getItem('user')).token : null),
      },
      redirect: 'follow',
      referrerPolicy: 'no-referrer',
    });

    if (!response.ok) {
      throw new Error('Nem lehet lekérdezni a kurzusokat');
    }
    console.log('allcourses lefutott');
    state.allCourses = await response.json();
  }
  catch(error) {
    throw error;
  }
}

  async getMyCourses(slug='', needAuth = true) {
    try{
      const response = await fetch(URL + slug, {
        method: 'GET',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json',
          Authorization: 'Bearer ' + (needAuth ? JSON.parse(localStorage.getItem('user')).token : null),
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
      });
  
      if (!response.ok) {
        throw new Error('Nem lehet lekérdezni a hallgató kurzusait');
      }
      console.log('mycourses lefutott');
      let myCourses = await response.json();
      state.myCourses=myCourses.filter(course => course.userId === state.loggedInUser.id).map(course => {
        state.allCourses[course.courseId-1].enrolled = true;
        return state.allCourses[course.courseId-1]
      });
    }
    catch(error) {
      throw error;
    }
  }

  findUser() {
    console.log('find user lefutott')
    let username = JSON.parse(localStorage.getItem('user')).userName;
    const user = state.users.find(
      user => user.userName === username
    );
    state.loggedInUser = user;
  }
}

export const model = new Model();
