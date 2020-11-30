import React, { useState, useEffect } from 'react';
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import { useRouteMatch } from 'react-router-dom';
import moment from 'moment';
import axiosInstance from '../../utils/request';

const ListaBancadaPlantacoes = () => {
  const { bancadaId } = useRouteMatch().params;
  const [bancada, setBancada] = useState(null)

  useEffect(() => {
    const getBancada = async () => {
      try {
        // 'buscar bancadas'
        const response = await axiosInstance.get(`Bancada/${bancadaId}`);

        // 'modifico o estado das bancadas, setBancadas(listagem)'
        setBancada(response.data);
      } catch (err) {
        console.error('erro', err)
      }
    }
    getBancada();
  }, [bancadaId])

  return <Row>
    <Col>
      <Card>
        <CardHeader>
          <strong>Lista de plantações da bancada: {bancada?.nome}</strong>
        </CardHeader>
        <CardBody>
          <Table hover bordered striped responsive size="sm">
            <thead>
              <tr>
                <th>Número</th>
                <th>Tipo de semeio</th>
                <th>Data de Criação</th>
                <th>Data de Término</th>
                <th>Bancada</th>
              </tr>
            </thead>
            {bancada?.plantacoes?.map(plantacao => (
              <tbody key={plantacao.idPlantacao}>
                <tr>
                  <td>{plantacao.idPlantacao}</td>
                  <td>{plantacao.semeio}</td>
                  <td>{moment(plantacao.dataInicio).format("DD/MM/YYYY")}</td>
                  <td>{moment(plantacao.dataFim).format("DD/MM/YYYY")}</td>
                  <td>{plantacao.nomeBancada}</td>
                </tr>
              </tbody>
            ))}
          </Table>
        </CardBody>
      </Card>
    </Col>
  </Row>
}

export default ListaBancadaPlantacoes;