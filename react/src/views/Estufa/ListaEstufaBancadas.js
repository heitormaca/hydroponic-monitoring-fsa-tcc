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
                <strong>Lista de bancadas da estufa: Estufa 01</strong>
              </CardHeader>
              <CardBody>
                <Table hover bordered striped responsive size="sm">
                  <thead>
                    <tr>
                      <th>Número</th>
                      <th>Nome</th>
                      <th>Data de Criação</th>
                      <th>Localização</th>
                      <th>Estufa</th>
                      <th>Dispositivo</th>
                      <th>Plantações</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>0001</td>
                      <td><Link to="/bancadas/bancada">Bancada 01</Link></td>
                      <td>01/10/2020</td>
                      <td>Setor A5</td>
                      <td>Estufa 01</td>
                      <td>Dispositivo 01</td>
                      <td>1</td>
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