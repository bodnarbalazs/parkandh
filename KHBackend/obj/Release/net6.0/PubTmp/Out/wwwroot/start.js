// window.addEventListener('load', () => {
//     const animation = document.querySelector('.animation');
//     animation.addEventListener('animationend', () => {
//       animation.classList.remove('animation');
//     });
//   });
  

function stopanimation() {
    const animation = document.querySelector('.animation');
    animation.classList.remove('animation');
  }
  


document.onload = () => {
    setTimeout(stopanimation, 3000);
  };