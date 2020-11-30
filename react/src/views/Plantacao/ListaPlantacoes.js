import React, { useEffect, useState } from 'react';
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import { Link } from 'react-router-dom';
import moment from 'moment';
import axiosInstance from '../../utils/request';

const ListaPlantacoes = () => {
  const [plantacoes, setPlantacoes] = useState([]);

  useEffect(() => {
    const getPlantacoes = async () => {
      try {
        // 'buscar plantações'
        const response = await axiosInstance.get(`Plantacao`);

        // 'modifico o estado das plantações, setPLantacoes(listagem)
        setPlantacoes(response.data);

      } catch (err) {
        console.error('erro', err)
      }
    }
    getPlantacoes();
  }, [])

  return <Row>
    <Col>
      <Card>
        <CardHeader>
          <strong>Lista de plantações</strong>
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
            <tbody>
              {plantacoes.map(plantacao => (
                <tr key={plantacao.idPlantacao}>
                  <td>{plantacao.idPlantacao}</td>
                  <td><Link to={`/plantacao/plantacao-item/${plantacao.idPlantacao}`}>{plantacao.semeio}</Link></td>
                  <td>{moment(plantacao.dataInicio).format("DD/MM/YYYY")}</td>
                  <td>{moment(plantacao.dataFim).format("DD/MM/YYYY")}</td>
                  <td>{plantacao.nomeBancada}</td>
                </tr>
              ))}
            </tbody>
          </Table>
        </CardBody>
      </Card>
    </Col>
  </Row>
}

export default ListaPlantacoes;