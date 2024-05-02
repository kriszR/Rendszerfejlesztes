export const checkLogin = function () {
  if (!localStorage.getItem('user')) {
    window.location.href = 'login.html';
  }
};
