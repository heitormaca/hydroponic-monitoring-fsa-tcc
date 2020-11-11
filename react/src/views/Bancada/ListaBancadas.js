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
                      <td><Link to="/bancada/lista-bancada-plantacoes">Bancada 01</Link></td>
                      <td>01/10/2020</td>
                      <td>Setor A5</td>
                      <td>Estufa 01</td>
                      <td>Dispositivo 01</td>
                      <td>2</td>
                    </tr>
                    <tr>
                      <td>0002</td>
                      <td>Bancada 02</td>
                      <td>05/10/2020</td>
                      <td>Setor B2</td>
                      <td>Estufa 02</td>
                      <td>Dispositivo 02</td>
                      <td>1</td>
                    </tr>
                    <tr>
                      <td>0003</td>
                      <td>Bancada 03</td>
                      <td>08/10/2020</td>
                      <td>Setor C4</td>
                      <td>Estufa 03</td>
                      <td>Dispositivo 03</td>
                      <td>2</td>
                    </tr>
                    <tr>
                      <td>0004</td>
                      <td>Bancada 04</td>
                      <td>10/10/2020</td>
                      <td>Setor B3</td>
                      <td>Estufa 02</td>
                      <td>Dispositivo 04</td>
                      <td>0</td>
                    </tr>
                    <tr>
                      <td>0005</td>
                      <td>Bancada 05</td>
                      <td>12/10/2020</td>
                      <td>Setor C1</td>
                      <td>Estufa 03</td>
                      <td>Dispositivo 05</td>
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

export default ListaBancadas;