// wwwroot/js/modal.js
window.addKeyPressListener = (dotNetHelper) => {
  document.addEventListener('keydown', (event) => {
      if (event.key === 'Escape') {
          dotNetHelper.invokeMethodAsync('CloseModal');
      }
  });
};

window.removeKeyPressListener = () => {
  document.removeEventListener('keydown', (event) => {
      if (event.key === 'Escape') {
          // Função vazia para não fazer nada
      }
  });
};
