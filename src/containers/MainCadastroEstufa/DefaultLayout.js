import React, { Component, Suspense } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import * as router from 'react-router-dom';
import { 
  Conta, FormGroup, Forminer, 
  // FormGroup,
  Col, 
  Card, 
  Input,
  CardBody,
  CardHeader,
  Form,
  Label,
  FormText,
  CardFooter,
  Button,
} from 'reactstrap';

import {
  AppAside,
  AppFooter,
  AppHeader,
  AppSidebar,
  AppSidebarFooter,
  AppSidebarForm,
  AppSidebarHeader,
  AppSidebarMinimizer,
  AppBreadcrumb2 as AppBreadcrumb,
  AppSidebarNav2 as AppSidebarNav,
} from '@coreui/react';
// sidebar nav config
import navigation from '../../_nav';
// routes config
import routes from '../../routes';

const DefaultAside = React.lazy(() => import('./DefaultAside'));
const DefaultFooter = React.lazy(() => import('./DefaultFooter'));
const DefaultHeader = React.lazy(() => import('./DefaultHeader'));

class DefaultLayout extends Component {

  loading = () => <div className="animated fadeIn pt-1 text-center">Loading...</div>

  signOut(e) {
    e.preventDefault()
    this.props.history.push('/login')
  }

  render() {
    return (
      <div className="app">
        <AppHeader fixed>
          <Suspense  fallback={this.loading()}>
            <DefaultHeader onLogout={e=>this.signOut(e)}/>
          </Suspense>
        </AppHeader>
        <div className="app-body">
          <AppSidebar fixed display="lg">
            <AppSidebarHeader />
            <AppSidebarForm />
            <Suspense>
            <AppSidebarNav navConfig={navigation} {...this.props} router={router}/>
            </Suspense>
            <AppSidebarFooter />
            <AppSidebarMinimizer />
          </AppSidebar>
          <main className="main">
            <Card>
              <CardHeader>
                <strong>Cadastro de estufa</strong>
              </CardHeader>
              <CardBody>
                <Form action="" method="post">
                  {/* <FormGroup>
                    <Label htmlFor="nf-email">Nome</Label>
                    <Input type="text" id="nf-name" name="nf-name" placeholder="Ex: Estufa 01" autoComplete="nome"/>
                    <FormText className="help-block">Insira o nome da estufa</FormText>
                  </FormGroup> */}
                  <FormGroup row className="my-0">
                    <Col xs="">
                      <Label htmlFor="nf-email">Nome</Label>
                      <Input type="text" id="nf-name" name="nf-name" placeholder="Ex: Estufa 01" autoComplete="nome"/>
                      <FormText className="help-block">Insira o nome da estufa</FormText>
                    </Col>
                  </FormGroup>
                  <FormGroup row className="my-0">
                    <Col xs="3">
                      <FormGroup>
                        <Label htmlFor="city">Temperatura Máxima (°C)</Label>
                        <Input type="text" id="city" placeholder="Ex: 30" />
                        <FormText className="help-block">Insira a temperatura máxima da estufa</FormText>  
                      </FormGroup>
                    </Col>
                    <Col xs="3">
                      <FormGroup>
                        <Label htmlFor="postal-code">Temperatura Mínima (°C)</Label>
                        <Input type="text" id="postal-code" placeholder="Ex: 15" />
                        <FormText className="help-block">Insira a temperatura mínima da estufa</FormText>  
                      </FormGroup>
                    </Col>
                  </FormGroup>
                </Form>
                  <Button type="submit" size="sm" color="primary">Cadastrar</Button>
                </CardBody>
              </Card>
            </main>
          <AppAside fixed>
            <Suspense fallback={this.loading()}>
              <DefaultAside />
            </Suspense>
          </AppAside>
        </div>
        <AppFooter>
          <Suspense fallback={this.loading()}>
            <DefaultFooter />
          </Suspense>
        </AppFooter>
      </div>
    );
  }
}

export default DefaultLayout;
