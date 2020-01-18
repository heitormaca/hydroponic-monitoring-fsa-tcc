import React, { Component } from 'react';
import { Badge, Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';

class Estufa extends Component {

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

export default Estufa;