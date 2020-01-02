export default {
  items: [
    {
      name: 'Dashboard',
      url: '/dashboard',
      icon: 'icon-speedometer',
      badge: {
        variant: 'info',
        // text: 'NEW',
      },
    },
    {
      name: 'Estufa',
      icon: 'icon-home',
      children: [
        {
          name: 'Lista',
          url: '/cadastroestufa',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/cadastroestufa',
          icon: 'icon-note',
          // icon-drop
        },
      ],
    },
    {
      name: 'Bancada',
      icon: 'icon-drop',
      children: [
        {
          name: 'Lista',
          url: '/cadastrobancada',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/cadastrobancada',
          icon: 'icon-note',
          // icon-drop
        },
      ],
    },
  ],
};
