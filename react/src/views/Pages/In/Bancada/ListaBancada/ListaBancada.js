import React, { Component } from 'react';
import { Badge, Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';

class ListaBancada extends Component {

  render() {
    return (
      <div>
        <Row>
          <Col>
            <Card>
              <CardHeader>
                <strong>Lista de bancada</strong>
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
                      <td>Estufa 01</td>
                      <td>
                        <Badge color="success">ATIVO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0002</td>
                      <td>Bancada 02</td>
                      <td>12/06/2019</td>
                      <td>Estufa 03</td>
                      <td>
                        <Badge color="danger">FINALIZADO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0003</td>
                      <td>Bancada 03</td>
                      <td>14/06/2019</td>
                      <td>Estufa 03</td>
                      <td>
                        <Badge color="secondary">INATIVO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0004</td>
                      <td>Bancada 04</td>
                      <td>14/06/2019</td>
                      <td>Estufa 02</td>
                      <td>
                        <Badge color="danger">FINALIZADO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0005</td>
                      <td>Bancada 05</td>
                      <td>16/06/2019</td>
                      <td>Estufa 02</td>
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

export default ListaBancada;