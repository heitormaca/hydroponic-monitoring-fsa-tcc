import React, { Component, useState, useEffect } from 'react';
import { Badge, Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import { Link, useRouteMatch } from 'react-router-dom';
import axiosInstance from '../../utils/request';

const ListaEstufaBancadas = () => {
  const { estufaId } = useRouteMatch();

  const [estufa, setEstufa] = useState(null)

  useEffect(() => {
    const getEstufa = async () => {
      try {
        // 'buscar estufas'
        const response = await axiosInstance.get(`Estufa/${estufaId}`);

        // 'modifico o estado das estufas, setEstufas(listagem)
        setEstufa(response.data);
      } catch (err) {
        console.error('deu erro', err)
      }
    }
    getEstufa();
  }, [])

  console.log(estufa)

  return <Row>
    <Col>
      <Card>
        <CardHeader>
          <strong>Lista de bancadas da estufa: {estufa.nome}</strong>
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
                <td>Bancada 01</td>
                <td>01/10/2020</td>
                <td>Setor A5</td>
                <td>Estufa 01</td>
                <td>Dispositivo 01</td>
                <td>2</td>
              </tr>
            </tbody>
          </Table>
        </CardBody>
      </Card>
    </Col>
  </Row>
}

// class ListaBancadas extends Component {

//   render() {
//     return (
//       <div>
//         <Row>
//           <Col>
//             <Card>
//               <CardHeader>
//                 <strong>Lista de bancadas da estufa: Estufa 01</strong>
//               </CardHeader>
//               <CardBody>
//                 <Table hover bordered striped responsive size="sm">
//                   <thead>
//                     <tr>
//                       <th>Número</th>
//                       <th>Nome</th>
//                       <th>Data de Criação</th>
//                       <th>Localização</th>
//                       <th>Estufa</th>
//                       <th>Dispositivo</th>
//                       <th>Plantações</th>
//                     </tr>
//                   </thead>
//                   <tbody>
//                     <tr>
//                       <td>0001</td>
//                       <td>Bancada 01</td>
//                       <td>01/10/2020</td>
//                       <td>Setor A5</td>
//                       <td>Estufa 01</td>
//                       <td>Dispositivo 01</td>
//                       <td>2</td>
//                     </tr>
//                   </tbody>
//                 </Table>
//               </CardBody>
//             </Card>
//           </Col>
//         </Row>
//       </div>
//     );
//   }
// }

export default ListaEstufaBancadas;