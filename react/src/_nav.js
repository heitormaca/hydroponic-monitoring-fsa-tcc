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
      url: '/estufas',
      icon: 'icon-home',
      children: [
        {
          name: 'Lista',
          url: '/estufas/listaestufas',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/estufas/cadastroestufa',
          icon: 'icon-note',
        },
      ],
    },
    {
      name: 'Bancada',
      url: '/bancadas',
      icon: 'icon-drop',
      children: [
        {
          name: 'Lista',
          url: '/bancadas/listabancadas',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/bancadas/cadastrobancada',
          icon: 'icon-note',
        },
      ],
    },
  ],
};
