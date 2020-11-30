import React, { useEffect, useState } from 'react';
import { Col, Card, CardBody, Row, Container, CardGroup } from 'reactstrap';
import axiosInstance from '../../utils/request';

const Perfil = () => {
  const [produtor, setProdutor] = useState(null);

  useEffect(() => {
    const getProdutor = async () => {
      try {
        // 'buscar produtor logado'
        const produtorResponse = await axiosInstance.get(`Produtor`);
        setProdutor(produtorResponse.data);
      } catch (err) {
        console.error('erro', err)
      }
    }
    getProdutor();
  }, []);

  return <Container>
    <Row className="justify-content-center">
      <Col md="5">
        <CardGroup>
          <Card className="p-4">
            <CardBody>
              <Row className="justify-content-center my-3">
                <img src={'../../assets/img/users/fazendeiro.jpg'} className="img-avatar w-50 float-center" alt="admin@bootstrapmaster.com" />
              </Row>
              <h2 className="my-3">Perfil</h2>
              <p className="my-0">Nome:</p> 
              <p>{produtor?.nome}</p>
              <p className="my-0">Email:</p> 
              <p>{produtor?.email}</p>
            </CardBody>
          </Card>
        </CardGroup>
      </Col>
    </Row>
  </Container>
}

export default Perfil;
