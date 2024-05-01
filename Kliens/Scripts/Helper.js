export const checkLogin = function () {
  if (!localStorage.getItem('user')) {
    console.log('Nincs bejelentkezve');
    window.location.href = 'login.html';
  }
};
