import React, { useEffect, useState } from 'react';
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import { Link } from 'react-router-dom';
import moment from 'moment'
import axiosInstance from '../../utils/request';

const ListaEstufas = () => {
  const [estufas, setEstufas] = useState([]);

  useEffect(() => {
    const getEstufas = async () => {
      try {
        // 'buscar estufas'
        const response = await axiosInstance.get(`Estufa`);

        // 'modifico o estado das estufas, setEstufas(listagem)
        setEstufas(response.data);

      } catch (err) {
        console.error('erro', err)
      }
    }
    getEstufas();
  }, [])

  return <Row>
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
                <th>Localização</th>
                <th>Bancadas</th>
              </tr>
            </thead>
            {estufas.map(estufa => (
              <tbody key={estufa.idEstufa}>
                <tr>
                  <td>{estufa.idEstufa}</td>
                  <td><Link to={`/estufa/lista-estufa-bancadas/${estufa.idEstufa}`}>{estufa.nome}</Link></td>
                  <td>{moment(estufa.dataInicio).format("DD/MM/YYYY")}</td>
                  <td>{estufa.localizacao}</td>
                  <td>{estufa.qtdBancada}</td>
                </tr>
              </tbody>
            ))}
          </Table>
        </CardBody>
      </Card>
    </Col>
  </Row>
}

export default ListaEstufas;