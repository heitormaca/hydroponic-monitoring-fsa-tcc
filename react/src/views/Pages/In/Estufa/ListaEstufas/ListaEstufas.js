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
                <strong>Lista de estufas</strong>
              </CardHeader>
              <CardBody>
                <Table hover bordered striped responsive size="sm">
                  <thead>
                    <tr>
                      <th>Número</th>
                      <th>Nome</th>
                      <th>Data de Criação</th>
                      <th>Bancadas</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>0001</td>
                      <td><Link to="/estufas/estufa">Estufa 01</Link></td>
                      <td>01/10/2020</td>
                      <td>0</td>
                    </tr>
                    <tr>
                      <td>0002</td>
                      <td><Link to="#">Estufa 02</Link></td>
                      <td>12/06/2019</td>
                      <td>1</td>
                    </tr>
                    <tr>
                      <td>0003</td>
                      <td><Link to="#">Estufa 03</Link></td>
                      <td>14/06/2019</td>
                      <td>1</td>
                    </tr>
                    <tr>
                      <td>0004</td>
                      <td><Link to="#">Estufa 04</Link></td>
                      <td>14/06/2019</td>
                      <td>0</td>
                    </tr>
                    <tr>
                      <td>0005</td>
                      <td><Link to="#">Estufa 05</Link></td>
                      <td>16/06/2019</td>
                      <td>0</td>
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