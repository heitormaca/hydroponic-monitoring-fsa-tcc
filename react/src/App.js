import React, { Component } from 'react';
import { HashRouter, Route, Switch } from 'react-router-dom';
import './App.scss';

const loading = () => <div className="animated fadeIn pt-3 text-center">Loading...</div>;

// Containers
const DefaultLayout = React.lazy(() => import('./containers/Dashboard/Layout'));
const CadastroEstufa = React.lazy(() => import('./containers/CadastroEstufa/Layout'));
const CadastroBancada = React.lazy(() => import('./containers/CadastroBancada/Layout'));
const ListaEstufa = React.lazy(() => import('./containers/ListaEstufa/Layout'))
const ListaBancada = React.lazy(() => import('./containers/ListaBancada/Layout'))
const Bancada = React.lazy(() => import('./containers/Bancada/Layout'))
const Estufa = React.lazy(() => import('./containers/Estufa/Layout'))
const PerfilDeUsuario = React.lazy(() => import('./containers/PerfilDeUsuario/Layout'))
const AlterarSenha = React.lazy(() => import('./containers/AlterarSenha/Layout'))

// Pages
const EsqueciSenha = React.lazy(() => import('./views/Pages/EsqueciSenha/EsqueciSenha'));
const Login = React.lazy(() => import('./views/Pages/Login/Login'));
const Register = React.lazy(() => import('./views/Pages/Register/Register'));
const Page404 = React.lazy(() => import('./views/Pages/Page404/Page404'));
const Page500 = React.lazy(() => import('./views/Pages/Page500/Page500'));

class App extends Component {

  render() {
    return (
      <HashRouter>
          <React.Suspense fallback={loading()}>
            <Switch>
              <Route exact path="/perfildeusuario" name="Perfil de Usuario" render={props => <PerfilDeUsuario {...props}/>} />
              <Route exact path="/alterarsenha" name="Alterar Senha" render={props => <AlterarSenha {...props}/>} />
              <Route exact path="/cadastroestufa" name="Cadastro Estufa" render={props => <CadastroEstufa {...props}/>} />
              <Route exact path="/cadastrobancada" name="Cadastro Bancada" render={props => <CadastroBancada {...props}/>} />
              <Route exact path="/listaestufa" name="Lista Estufa" render={props => <ListaEstufa {...props}/>} />
              <Route exact path="/listabancada" name="Lista Bancada" render={props => <ListaBancada {...props}/>} />
              <Route exact path="/Estufa" name="Estufa" render={props => <Estufa {...props}/>} />
              <Route exact path="/Bancada" name="Bancada" render={props => <Bancada {...props}/>} />
              <Route exact path="/esquecisenha" name="Esqueci a Senha" render={props => <EsqueciSenha {...props}/>} />
              <Route exact path="/login" name="Login" render={props => <Login {...props}/>} />
              <Route exact path="/register" name="Registro" render={props => <Register {...props}/>} />
              <Route exact path="/404" name="Page 404" render={props => <Page404 {...props}/>} />
              <Route exact path="/500" name="Page 500" render={props => <Page500 {...props}/>} />
              <Route path="/" name="Home" render={props => <DefaultLayout {...props}/>} />

            </Switch>
          </React.Suspense>
      </HashRouter>
    );
  }
}

export default App;
