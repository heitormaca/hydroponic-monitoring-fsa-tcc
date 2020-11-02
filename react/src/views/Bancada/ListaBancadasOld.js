import React, { Component } from 'react';
import { Badge, Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import { Link } from 'react-router-dom';

class ListaBancadas extends Component {

  render() {
    return (
      <div>
        <Row>
          <Col>
            <Card>
              <CardHeader>
                <strong>Lista de bancadas</strong>
              </CardHeader>
              <CardBody>
                <Table hover bordered striped responsive size="sm">
                  <thead>
                    <tr>
                      <th>Número</th>
                      <th>Nome</th>
                      <th>Tipo de semeio</th>
                      <th>Data de Criação</th>
                      <th>Estufa</th>
                      <th>Status</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>0001</td>
                      <td><Link to="/bancadas/bancada">Bancada 01</Link></td>
                      <td>Alface</td>
                      <td>01/10/2020</td>
                      <td>Estufa 01</td>
                      <td>
                        <Badge color="success">ATIVO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0002</td>
                      <td><Link to="#">Bancada 02</Link></td>
                      <td>Repolho</td>
                      <td>12/06/2019</td>
                      <td>Estufa 01</td>
                      <td>
                        <Badge color="danger">FINALIZADO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0003</td>
                      <td><Link to="#">Bancada 03</Link></td>
                      <td>Tomate</td>
                      <td>14/06/2019</td>
                      <td>Estufa 01</td>
                      <td>
                        <Badge color="secondary">INATIVO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0004</td>
                      <td><Link to="#">Bancada 04</Link></td>
                      <td>Brócolis</td>
                      <td>14/06/2019</td>
                      <td>Estufa 02</td>
                      <td>
                        <Badge color="danger">FINALIZADO</Badge>
                      </td>
                    </tr>
                    <tr>
                      <td>0005</td>
                      <td><Link to="#">Bancada 05</Link></td>
                      <td>Melão</td>
                      <td>16/06/2019</td>
                      <td>Estufa 03</td>
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

export default ListaBancadas;