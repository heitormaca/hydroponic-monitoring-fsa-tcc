import React, { useEffect, useState } from 'react';
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import { Link } from 'react-router-dom';
import moment from 'moment';
import axiosInstance from '../../utils/request';

const ListaBancadas = () => {
  const [bancadas, setBancadas] = useState([]);

  useEffect(() => {
    const getBancadas = async () => {
      try {
        // 'buscar bancadas'
        const response = await axiosInstance.get(`Bancada`);

        // 'modifico o estado das bancadas, setBancadas(listagem)
        setBancadas(response.data);

      } catch (err) {
        console.error('erro', err)
      }
    }
    getBancadas();
  }, [])

  return <Row>
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
            {bancadas.map(bancada => (
              <tbody key={bancada.idBancada}>
                <tr>
                  <td>{bancada.idBancada}</td>
                  <td><Link to={`/bancada/lista-bancada-plantacoes/${bancada.idBancada}`}>{bancada.nome}</Link></td>
                  <td>{moment(bancada.dataInicio).format("DD/MM/YYYY")}</td>
                  <td>{bancada.localizacao}</td>
                  <td>{bancada.nomeEstufa}</td>
                  <td>{bancada.nomeDispositivo}</td>
                  <td>{bancada.qtdPlantacao}</td>
                </tr>
              </tbody>
            ))}
          </Table>
        </CardBody>
      </Card>
    </Col>
  </Row>
}

export default ListaBancadas;