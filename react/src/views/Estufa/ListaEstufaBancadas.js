import React, { useState, useEffect } from 'react';
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import { useRouteMatch } from 'react-router-dom';
import moment from 'moment';
import axiosInstance from '../../utils/request';

const ListaEstufaBancadas = () => {
  const { estufaId } = useRouteMatch().params;

  const [estufa, setEstufa] = useState(null)

  useEffect(() => {
    const getEstufa = async () => {
      try {
        // 'buscar estufas'
        const response = await axiosInstance.get(`Estufa/${estufaId}`);

        // 'modifico o estado das estufas, setEstufas(listagem)
        setEstufa(response.data);
      } catch (err) {
        console.error('erro', err)
      }
    }
    getEstufa();
  }, [estufaId])

  return <Row>
    <Col>
      <Card>
        <CardHeader>
          <strong>Lista de bancadas da estufa: {estufa?.nome}</strong>
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
            {estufa?.bancadas?.map(bancada => (
              <tbody key={bancada.idBancada}>
                <tr>
                  <td>{bancada.idBancada}</td>
                  <td>{bancada.nome}</td>
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

export default ListaEstufaBancadas;