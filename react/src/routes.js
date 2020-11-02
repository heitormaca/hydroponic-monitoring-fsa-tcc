import React from 'react';
const Perfil = React.lazy(() => import('./views/Conta/Perfil'))
const AlterarSenha = React.lazy(() => import('./views/Conta/AlterarSenha'))
const ListaEstufaBancadas = React.lazy(() => import('./views/Estufa/ListaEstufaBancadas'))
const ListaEstufas = React.lazy(() => import('./views/Estufa/ListaEstufas'))
const CadastroEstufa = React.lazy(() => import('./views/Estufa/CadastroEstufa'))
const Bancada = React.lazy(() => import('./views/Bancada/Bancada'))
const ListaBancadas = React.lazy(() => import('./views/Bancada/ListaBancadas'))
const CadastroBancada = React.lazy(() => import('./views/Bancada/CadastroBancada'))
const Dashboard = React.lazy(() => import('./views/Dashboard'));
const routes = [
  { path: '/', exact: true, name: 'Home' },
  { path: '/dashboard', name: 'Dashboard', component: Dashboard },
  { path: '/conta', exact: true, name: 'Conta', component: Perfil },
  { path: '/conta/perfil', name: 'Perfil', component: Perfil },
  { path: '/conta/alterar-senha', name: 'Alterar Senha', component: AlterarSenha },
  { path: '/estufa/lista-estufas', exact: true, name: 'Estufas', component: ListaEstufas },
  { path: '/estufa/estufa', name: 'Estufa', component: ListaEstufaBancadas },
  { path: '/estufa/bancada', name: 'Bancada', component: Bancada },
  { path: '/estufa/lista-estufa-bancadas', name: 'Lista de Estufas', component: ListaEstufas },
  { path: '/estufa/cadastro-estufa', name: 'Cadastro de Estufa', component: CadastroEstufa },
  // { path: '/bancada', exact: true, name: 'Bancadas', component: ListaBancadas },
  { path: '/bancada/bancada', name: 'Bancada', component: Bancada },
  { path: '/bancada/lista-bancadas', name: 'Lista de Bancadas', component: ListaBancadas },
  { path: '/bancada/cadastro-bancada', name: 'Cadastro de Bancada', component: CadastroBancada },
];

export default routes;
