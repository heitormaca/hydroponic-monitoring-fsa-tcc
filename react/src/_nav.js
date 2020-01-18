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
      url: '/estufa',
      icon: 'icon-home',
      children: [
        {
          name: 'Lista',
          url: '/estufa/listaestufa',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/estufa/cadastroestufa',
          icon: 'icon-note',
        },
      ],
    },
    {
      name: 'Bancada',
      url: '/bancada',
      icon: 'icon-drop',
      children: [
        {
          name: 'Lista',
          url: '/bancada/listabancada',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/bancada/cadastrobancada',
          icon: 'icon-note',
        },
      ],
    },
  ],
};
