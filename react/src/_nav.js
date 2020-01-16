export default {
  items: [
    {
      name: 'Dashboard',
      url: '/dashboard',
      icon: 'icon-speedometer',
      badge: {
        variant: 'info',
      },
    },
    {
      name: 'Estufa',
      icon: 'icon-home',
      children: [
        {
          name: 'Lista',
          url: '/listaestufa',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/cadastroestufa',
          icon: 'icon-note',
        },
      ],
    },
    {
      name: 'Bancada',
      icon: 'icon-drop',
      children: [
        {
          name: 'Lista',
          url: '/listabancada',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/cadastrobancada',
          icon: 'icon-note',
        },
      ],
    },
  ],
};
