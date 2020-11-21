import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import './App.scss';

const loading = () => <div className="animated fadeIn pt-3 text-center">Loading...</div>;

// Containers
const DefaultLayout = React.lazy(() => import('./containers/DefaultLayout'));

// Pages
const EsqueciSenha = React.lazy(() => import('./views/EsqueciSenha'));
const Login = React.lazy(() => import('./views/Login'));
const Cadastro = React.lazy(() => import('./views/Cadastro'));
const Page404 = React.lazy(() => import('./views/Page404'));
const Page500 = React.lazy(() => import('./views/Page500'));

class App extends Component {

  render() {
    return (
      <BrowserRouter>
          <React.Suspense fallback={loading()}>
            <Switch>
              <Route exact path="/esqueci-senha" name="Esqueci a Senha" render={props => <EsqueciSenha {...props}/>} />
              <Route exact path="/login" name="Login" render={props => <Login {...props}/>} />
              <Route exact path="/cadastro" name="Cadastro" render={props => <Cadastro {...props}/>} />
              <Route exact path="/404" name="Page 404" render={props => <Page404 {...props}/>} />
              <Route exact path="/500" name="Page 500" render={props => <Page500 {...props}/>} />
              <Route path="/" name="Home" render={props => <DefaultLayout {...props}/>} />
            </Switch>
          </React.Suspense>
      </BrowserRouter>
    );
  }
}

export default App;
