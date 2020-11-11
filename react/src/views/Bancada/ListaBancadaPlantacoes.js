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
                <strong>Lista de plantações da bancada: Bancada 01</strong>
              </CardHeader>
              <CardBody>
                <Table hover bordered striped responsive size="sm">
                  <thead>
                    <tr>
                      <th>Número</th>
                      <th>Nome</th>
                      <th>Tipo de semeio</th>
                      <th>Data de Criação</th>
                      <th>Data de Término</th>
                      <th>Bancada</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>0001</td>
                      <td>Plantação 01</td>
                      <td>Alface</td>
                      <td>01/06/2020</td>
                      <td>01/09/2020</td>
                      <td>Bancada 01</td>
                    </tr>
                    <tr>
                      <td>0002</td>
                      <td>Plantação 02</td>
                      <td>Repolho</td>
                      <td>02/09/2020</td>
                      <td>04/11/2020</td>
                      <td>Bancada 01</td>
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