import React, { Component } from 'react';
import { 
  Col,
  Card, 
  CardBody,
  Row,
  Container,
  CardGroup,
  Button,
} from 'reactstrap';

class Perfil extends Component {

  render() {
    return (
        <div>
        <Container>
          <Row className="justify-content-center">
            <Col md="5">
              <CardGroup>
                <Card className="p-4">
                  <CardBody>
                    <Row className="justify-content-center my-3">
                      <img src={'../../assets/img/users/fazendeiro.jpg'} className="img-avatar w-50 float-center" alt="admin@bootstrapmaster.com" />
                    </Row>
                    <Button block color="ghost-dark" size="lg"><strong>ALTERAR FOTO</strong></Button>
                    <h2 className="my-3">Perfil</h2>
                    <p className="my-0">Nome:</p> 
                    <p>Sr. Agricultor</p>
                    <p className="my-0">Email:</p> 
                    <p>sragricultor@example.com</p>

                  </CardBody>
                </Card>
              </CardGroup>
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}

export default Perfil;
