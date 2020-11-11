import React from 'react';
const Dashboard = React.lazy(() => import('./views/Dashboard'));
const Perfil = React.lazy(() => import('./views/Conta/Perfil'))
const AlterarSenha = React.lazy(() => import('./views/Conta/AlterarSenha'))
const ListaEstufas = React.lazy(() => import('./views/Estufa/ListaEstufas'))
const ListaEstufaBancadas = React.lazy(() => import('./views/Estufa/ListaEstufaBancadas'))
const CadastroEstufa = React.lazy(() => import('./views/Estufa/CadastroEstufa'))
const ListaBancadas = React.lazy(() => import('./views/Bancada/ListaBancadas'))
const ListaBancadaPlantacoes = React.lazy(() => import('./views/Bancada/ListaBancadaPlantacoes'))
const CadastroBancada = React.lazy(() => import('./views/Bancada/CadastroBancada'))
const Plantacao = React.lazy(() => import('./views/Plantacao/ListaPlantacoes'))
const ListaPlantacoes = React.lazy(() => import('./views/Plantacao/ListaPlantacoes'))
const CadastroPlantacao = React.lazy(() => import('./views/Plantacao/CadastroPlantacao'))
const PlantacaoItem = React.lazy(() => import('./views/Plantacao/Plantacao'))
const routes = [
  { path: '/', exact: true, name: 'Home', component: Dashboard },
  { path: '/dashboard', name: 'Dashboard', component: Dashboard },
  { path: '/conta', exact: true, name: 'Conta', component: Perfil },
  { path: '/conta/perfil', name: 'Perfil', component: Perfil },
  { path: '/conta/alterar-senha', name: 'Alterar Senha', component: AlterarSenha },
  { path: '/estufa', exact: true, name: 'Lista de Estufas', component: ListaEstufas },
  { path: '/estufa/lista-estufas', exact: true, name: 'Lista de Estufas', component: ListaEstufas },
  { path: '/estufa/lista-estufa-bancadas', name: 'Lista de Bancadas na Estufa', component: ListaEstufaBancadas },
  { path: '/estufa/cadastro-estufa', name: 'Cadastro de Estufa', component: CadastroEstufa },
  { path: '/bancada', exact: true, name: 'Lista de Bancadas', component: ListaBancadas },
  { path: '/bancada/lista-bancadas', name: 'Lista de Bancadas', component: ListaBancadas },
  { path: '/bancada/lista-bancada-plantacoes', name: 'Lista de Plantações na Bancada', component: ListaBancadaPlantacoes },
  { path: '/bancada/cadastro-bancada', name: 'Cadastro de Bancada', component: CadastroBancada },
  { path: '/plantacao', exact: true, name: 'Lista de Plantações', component: Plantacao },
  { path: '/plantacao/lista-plantacoes', name: 'Lista de Plantações', component: ListaPlantacoes },
  { path: '/plantacao/cadastro-plantacao', name: 'Cadastro de Plantação', component: CadastroPlantacao },
  { path: '/plantacao/plantacao-item', name: 'Plantação', component: PlantacaoItem },
];

export default routes;
