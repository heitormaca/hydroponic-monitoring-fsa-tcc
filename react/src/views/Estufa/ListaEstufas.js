import React, { useEffect, useState } from 'react';
import { Badge, Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';
import { Link } from 'react-router-dom';
import axiosInstance from '../../utils/request';

const ListaEstufa = () => {
  const [estufas, setEstufas] = useState([]);

  useEffect(() => {
    const getEstufas = async () => {
      try {
        // 'buscar estufas'
        const response = await axiosInstance.get(`Estufa`);

        // 'modifico o estado das estufas, setEstufas(listagem)
        setEstufas(response.data);

      } catch (err) {
        console.error('deu erro', err)
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
                  <td><Link to={`/estufa/lista-estufa-bancadas/${estufa.idEstufa}`} > {estufa.nome}</Link></td>
                  <td>01/10/2020</td>
                  <td>Setor A</td>
                  <td>1</td>
                </tr>
              </tbody>
            ))}
          </Table>
        </CardBody>
      </Card>
    </Col>
  </Row>
}

// class ListaEstufa extends Component {

//   render() {
//     return (
//       <div>
//         <Row>
//           <Col>
//             <Card>
//               <CardHeader>
//                 <strong>Lista de estufas</strong>
//               </CardHeader>
//               <CardBody>
//                 <Table hover bordered striped responsive size="sm">
//                   <thead>
//                     <tr>
//                       <th>Número</th>
//                       <th>Nome</th>
//                       <th>Data de Criação</th>
//                       <th>Localização</th>
//                       <th>Bancadas</th>
//                     </tr>
//                   </thead>
//                   <tbody>
//                     <tr>
//                       <td>0001</td>
//                       <td><Link to="/estufa/lista-estufa-bancadas">Estufa 01</Link></td>
//                       <td>01/10/2020</td>
//                       <td>Setor A</td>
//                       <td>1</td>
//                     </tr>
//                     <tr>
//                       <td>0002</td>
//                       <td><Link to="#">Estufa 02</Link></td>
//                       <td>12/06/2019</td>
//                       <td>Setor B</td>
//                       <td>2</td>
//                     </tr>
//                     <tr>
//                       <td>0003</td>
//                       <td><Link to="#">Estufa 03</Link></td>
//                       <td>14/06/2019</td>
//                       <td>Setor C</td>
//                       <td>2</td>
//                     </tr>
//                     <tr>
//                       <td>0004</td>
//                       <td><Link to="#">Estufa 04</Link></td>
//                       <td>14/06/2019</td>
//                       <td>Setor D</td>
//                       <td>0</td>
//                     </tr>
//                     <tr>
//                       <td>0005</td>
//                       <td><Link to="#">Estufa 05</Link></td>
//                       <td>16/06/2019</td>
//                       <td>Setor E</td>
//                       <td>0</td>
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

export default ListaEstufa;