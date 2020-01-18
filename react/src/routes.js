import React from 'react';
const PerfilDoUsuario = React.lazy(() => import('./views/Pages/In/Conta/PerfilDoUsuario/PerfilDoUsuario'))
const AlterarSenha = React.lazy(() => import('./views/Pages/In/Conta/AlterarSenha/AlterarSenha'))
const Estufa = React.lazy(() => import('./views/Pages/In/Estufa/Estufa/Estufa'))
const ListaEstufa = React.lazy(() => import('./views/Pages/In/Estufa/ListaEstufa/ListaEstufa'))
const CadastroEstufa = React.lazy(() => import('./views/Pages/In/Estufa/CadastroEstufa/CadastroEstufa'))
const Bancada = React.lazy(() => import('./views/Pages/In/Bancada/Bancada/Bancada'))
const ListaBancada = React.lazy(() => import('./views/Pages/In/Bancada/ListaBancada/ListaBancada'))
const CadastroBancada = React.lazy(() => import('./views/Pages/In/Bancada/CadastroBancada/CadastroBancada'))
const Dashboard = React.lazy(() => import('./views/Pages/In/Dashboard/Dashboard'));

// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
  { path: '/', exact: true, name: 'Home' },
  { path: '/dashboard', name: 'Dashboard', component: Dashboard },
  { path: '/conta', exact: true, name: 'Conta', component: PerfilDoUsuario },
  { path: '/conta/perfildousuario', name: 'Perfil do Usuário', component: PerfilDoUsuario },
  { path: '/conta/alterarsenha', name: 'Alterar Senha', component: AlterarSenha },
  { path: '/estufa', exact: true, name: 'Estufa', component: ListaEstufa },
  { path: '/estufa/estufa', name: 'Estufa', component: Estufa },
  { path: '/estufa/listaestufa', name: 'Lista Estufa', component: ListaEstufa },
  { path: '/estufa/cadastroestufa', name: 'Cadastro Estufa', component: CadastroEstufa },
  { path: '/bancada', exact: true, name: 'Bancada', component: ListaBancada },
  { path: '/bancada/bancada', name: 'Bancada', component: Bancada },
  { path: '/bancada/listabancada', name: 'Lista Bancada', component: ListaBancada },
  { path: '/bancada/cadastrobancada', name: 'Cadastro Bancada', component: CadastroBancada },
];

export default routes;
