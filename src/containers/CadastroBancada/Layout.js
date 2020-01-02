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

const DefaultAside = React.lazy(() => import('../Aside/DefaultAside'));
const DefaultFooter = React.lazy(() => import('../Footer/DefaultFooter'));
const DefaultHeader = React.lazy(() => import('../Header/DefaultHeader'));

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
                <strong>CADASTRO DE BANCADA</strong>
              </CardHeader>
              <CardBody>
                <Form action="" method="post">
                  <FormGroup row className="my-0">
                    <Col xs="6">
                      <FormGroup>
                        <Label>Nome da Bancada</Label>
                        <Input type="text" id="nf-name" name="nf-name" placeholder="Ex: Bancada-01" />
                        <FormText className="help-block">Insira o nome da bancada</FormText>  
                      </FormGroup>
                    </Col>
                    <Col xs="6">
                      <FormGroup>
                        <Label>Tipo de Semeio</Label>
                        <Input type="text" id="type-sem" placeholder="Ex: Alface" />
                        <FormText className="help-block">Insira o tipo de semeio</FormText>  
                      </FormGroup>
                    </Col>
                  </FormGroup>
                  <FormGroup row className="my-0">
                    <Col xs="6">
                      <FormGroup>
                        <Label htmlFor="date-input">Date de Inicio</Label>
                        <Input type="date" id="date-input-i" name="date-input-i" placeholder="date" />
                        <FormText className="help-block">Insira a data de inicio da bancada</FormText>  
                      </FormGroup>
                    </Col>
                    <Col xs="6">
                      <FormGroup>
                        <Label htmlFor="date-input">Date de Fim</Label>
                        <Input type="date" id="date-input-f" name="date-input-f" placeholder="date" />
                        <FormText className="help-block">Insira a data de fim da bancada</FormText>  
                      </FormGroup>
                    </Col>
                  </FormGroup>
                  <FormGroup row className="my-0">
                    <Col xs="6">
                      <FormGroup>
                        <Label>Valor Máximo de PH</Label>
                        <Input type="number" id="maxPH" name="maxPH" placeholder="Ex: 5" min="0" max="14" step="0.1" />
                        <FormText className="help-block">Insira o valor máximo de PH da solução</FormText>  
                      </FormGroup>
                    </Col>
                    <Col xs="6">
                      <FormGroup>
                        <Label>Valor Mínimo de PH</Label>
                        <Input type="number" id="minPH" name="minPH" placeholder="Ex: 3" min="0" max="14" step="0.1" />
                        <FormText className="help-block">Insira o valor mínimo de PH da solução</FormText>  
                      </FormGroup>
                    </Col>
                  </FormGroup>
                  <FormGroup row className="my-0">
                    <Col xs="6">
                      <FormGroup>
                        <Label>Valor Máximo de EC</Label>
                        <Input type="number" id="maxEC" name="maxEC" placeholder="Ex: 10" min="0" max="100" step="0.1" />
                        <FormText className="help-block">Insira o valor máximo de EC da solução</FormText>  
                      </FormGroup>
                    </Col>
                    <Col xs="6">
                      <FormGroup>
                        <Label>Valor Mínimo de EC</Label>
                        <Input type="number" id="minEC" name="minEC"placeholder="Ex: 5" min="0" max="100" step="0.1" />
                        <FormText className="help-block">Insira o valor mínimo de EC da solução</FormText>  
                      </FormGroup>
                    </Col>
                  </FormGroup>
                  <FormGroup row className="my-0">
                    <Col xs="6">
                      <FormGroup>
                        <Label>Temperatura Máxima (°C)</Label>
                        <Input type="number" id="maxTemp" name="maxTemp" placeholder="Ex: 30" min="0" max="100" step="0.1"/>
                        <FormText className="help-block">Insira a temperatura máxima da bancada</FormText>   
                      </FormGroup>
                    </Col>
                    <Col xs="6">
                      <FormGroup>
                        <Label>Temperatura Mínima (°C)</Label>
                        <Input type="number" id="minTemp" name="minTemp" placeholder="Ex: 15" min="0" max="100" step="0.1"/>
                        <FormText className="help-block">Insira a temperatura mínima da bancada</FormText>  
                      </FormGroup>
                    </Col>
                  </FormGroup>
                  <FormGroup row className="my-0">
                    <Col xs="6">
                      <FormGroup>
                        <Label>Temperatura Máxima (°C)</Label>
                        <Input type="number" id="maxTemp" name="maxTemp" placeholder="Ex: 30" min="0" max="100" step="0.1"/>
                        <FormText className="help-block">Insira a temperatura máxima da solução</FormText>   
                      </FormGroup>
                    </Col>
                    <Col xs="6">
                      <FormGroup>
                        <Label>Temperatura Mínima (°C)</Label>
                        <Input type="number" id="minTemp" name="minTemp" placeholder="Ex: 15" min="0" max="100" step="0.1"/>
                        <FormText className="help-block">Insira a temperatura mínima da solução</FormText>  
                      </FormGroup>
                    </Col>
                  </FormGroup>
                </Form>
                  <Button type="submit" size="sm" color="primary">CADASTRAR</Button>
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
