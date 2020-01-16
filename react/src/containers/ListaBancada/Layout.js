import React, { Component, Suspense } from 'react';import * as router from 'react-router-dom';
import { Badge, Card, CardBody, CardHeader, Col, Pagination, PaginationItem, PaginationLink, Row, Table } from 'reactstrap';

import {
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
          <Row>
          <Col>
            <Card>
              <CardHeader>
                <strong>LISTA DE BANCADA</strong>
              </CardHeader>
              <CardBody>
                <Table hover bordered striped responsive size="sm">
                  <thead>
                  <tr>
                    <th>Número</th>
                    <th>Nome</th>
                    <th>Data de Criação</th>
                    <th>Estufa</th>
                    <th>Status</th>
                  </tr>
                  </thead>
                  <tbody>
                  <tr>
                    <td>0001</td>
                    <td>Bancada 01</td>
                    <td>12/06/2019</td>
                    <th>Estufa 01</th>
                    <td>
                      <Badge color="success">ATIVO</Badge>
                    </td>
                  </tr>
                  <tr>
                    <td>0002</td>
                    <td>Bancada 02</td>
                    <td>12/06/2019</td>
                    <th>Estufa 01</th>
                    <td>
                      <Badge color="danger">FECHADO</Badge>
                    </td>
                  </tr>
                  <tr>
                    <td>0003</td>
                    <td>Bancada 03</td>
                    <td>14/06/2019</td>
                    <th>Estufa 01</th>
                    <td>
                      <Badge color="secondary">INATIVO</Badge>
                    </td>
                  </tr>
                  <tr>
                    <td>0004</td>
                    <td>Bancada 04</td>
                    <td>14/06/2019</td>
                    <th>Estufa 01</th>
                    <td>
                      <Badge color="danger">FECHADO</Badge>
                    </td>
                  </tr>
                  <tr>
                    <td>0005</td>
                    <td>Bancada 05</td>
                    <td>16/06/2019</td>
                    <th>Estufa 01</th>
                    <td>
                      <Badge color="success">Activo</Badge>
                    </td>
                  </tr>
                  </tbody>
                </Table>
                {/* <nav>
                  <Pagination>
                    <PaginationItem><PaginationLink previous tag="button">Prev</PaginationLink></PaginationItem>
                    <PaginationItem active>
                      <PaginationLink tag="button">1</PaginationLink>
                    </PaginationItem>
                    <PaginationItem><PaginationLink tag="button">2</PaginationLink></PaginationItem>
                    <PaginationItem><PaginationLink tag="button">3</PaginationLink></PaginationItem>
                    <PaginationItem><PaginationLink tag="button">4</PaginationLink></PaginationItem>
                    <PaginationItem><PaginationLink next tag="button">Next</PaginationLink></PaginationItem>
                  </Pagination>
                </nav> */}
              </CardBody>
            </Card>
          </Col>
        </Row>
          </main>
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