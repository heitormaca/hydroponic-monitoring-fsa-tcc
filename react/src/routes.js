import React from 'react';
const Perfil = React.lazy(() => import('./views/Pages/In/Conta/Perfil/Perfil'))
const AlterarSenha = React.lazy(() => import('./views/Pages/In/Conta/AlterarSenha/AlterarSenha'))
const Estufa = React.lazy(() => import('./views/Pages/In/Estufa/Estufa/Estufa'))
const ListaEstufa = React.lazy(() => import('./views/Pages/In/Estufa/ListaEstufas/ListaEstufas'))
const CadastroEstufa = React.lazy(() => import('./views/Pages/In/Estufa/CadastroEstufa/CadastroEstufa'))
const Bancada = React.lazy(() => import('./views/Pages/In/Bancada/Bancada/Bancada'))
const ListaBancadas = React.lazy(() => import('./views/Pages/In/Bancada/ListaBancadas/ListaBancadas'))
const CadastroBancada = React.lazy(() => import('./views/Pages/In/Bancada/CadastroBancada/CadastroBancada'))
const Dashboard = React.lazy(() => import('./views/Pages/In/Dashboard/Dashboard'));

// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
  { path: '/', exact: true, name: 'Home' },
  { path: '/dashboard', name: 'Dashboard', component: Dashboard },
  { path: '/conta', exact: true, name: 'Conta', component: Perfil },
  { path: '/conta/perfil', name: 'Perfil', component: Perfil },
  { path: '/conta/alterarsenha', name: 'Alterar Senha', component: AlterarSenha },
  { path: '/estufas', exact: true, name: 'Estufas', component: ListaEstufa },
  { path: '/estufas/estufa', name: 'Estufa', component: Estufa },
  { path: '/estufas/bancada', name: 'Bancada', component: Bancada },
  { path: '/estufas/listaestufas', name: 'Lista de Estufas', component: ListaEstufa },
  { path: '/estufas/cadastroestufa', name: 'Cadastro de Estufa', component: CadastroEstufa },
  { path: '/bancadas', exact: true, name: 'Bancadas', component: ListaBancadas },
  { path: '/bancadas/bancada', name: 'Bancada', component: Bancada },
  { path: '/bancadas/listabancadas', name: 'Lista de Bancadas', component: ListaBancadas },
  { path: '/bancadas/cadastrobancada', name: 'Cadastro de Bancada', component: CadastroBancada },
];

export default routes;
