import React, { Component } from 'react';
import { Badge, Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import { Link } from 'react-router-dom';

class ListaEstufa extends Component {

  render() {
    return (
      <div>
        <Row>
          <Col>
            <Card>
              <CardHeader>
                <strong>Lista de estufa</strong>
              </CardHeader>
              <CardBody>
                <Table hover bordered striped responsive size="sm">
                  <thead>
                    <tr>
                      <th>Número</th>
                      <th>Nome</th>
                      <th>Data de Criação</th>
                      <th>Status</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>0001</td>
                      <Link to={'/estufa/estufa'}><td>Estufa 01</td></Link>
                      <td>12/06/2019</td>
                      <td>
                        <Badge color="success">ATIVO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0002</td>
                      <td>Estufa 02</td>
                      <td>12/06/2019</td>
                      <td>
                        <Badge color="danger">FECHADO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0003</td>
                      <td>Estufa 03</td>
                      <td>14/06/2019</td>
                      <td>
                        <Badge color="secondary">INATIVO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0004</td>
                      <td>Estufa 04</td>
                      <td>14/06/2019</td>
                      <td>
                        <Badge color="danger">FECHADO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0005</td>
                      <td>Estufa 05</td>
                      <td>16/06/2019</td>
                      <td>
                        <Badge color="success">ATIVO</Badge>
                      </td>
                    </tr>
                  </tbody>
                </Table>
              </CardBody>
            </Card>
          </Col>
        </Row>    
      </div>
    );
  }
}

export default ListaEstufa;