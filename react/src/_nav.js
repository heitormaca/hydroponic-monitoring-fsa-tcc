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
          url: '/estufa/lista-estufas',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/estufa/cadastro-estufa',
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
          url: '/bancada/lista-bancadas',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/bancada/cadastro-bancada',
          icon: 'icon-note',
        },
      ],
    },
    {
      name: 'Plantação',
      url: '/plantacao',
      icon: 'fa fa-leaf',
      children: [
        {
          name: 'Lista',
          url: '/plantacao/lista-plantacoes',
          icon: 'icon-list',
        },
        {
          name: 'Cadastro',
          url: '/plantacao/cadastro-plantacao',
          icon: 'icon-note',
        },
      ],
    },
  ],
};
