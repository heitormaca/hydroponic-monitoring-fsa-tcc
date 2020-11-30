import React, { Component, useEffect, useState } from 'react';
import {
  FormGroup,
  Col,
  Card,
  Input,
  CardBody,
  CardHeader,
  Form,
  Label,
  FormText,
  Button,
} from 'reactstrap';
import { useHistory } from 'react-router-dom';
import axiosInstance from '../../utils/request';

const CadastroBancada = () => {
  const history = useHistory();

  const [estufas, setEstufas] = useState([]);
  const [dispositivos, setDispositivos] = useState([]);

  const [nome, setNome] = useState('');
  const [localizacao, setLocalizacao] = useState('');
  const [estufaSelecionada, setEstufaSelecionada] = useState('');
  const [dispositivoSelecionado, setDispositivoSelecionado] = useState('');

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

  useEffect(() => {
    const getDispositivos = async () => {
      try {
        // 'buscar estufas'
        const response = await axiosInstance.get(`Dispositivo?naoMostrarVinculadas=true`);

        // 'modifico o estado das estufas, setDispositivos(listagem)
        setDispositivos(response.data);

      } catch (err) {
        console.error('erro', err)
      }
    }
    getDispositivos();
  }, [])

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const obj = { nome, localizacao, idEstufa: estufaSelecionada, idDispositivo: dispositivoSelecionado };

      const response = await axiosInstance.post('Bancada', obj);

      if (response.status === 200) {
        setNome('');
        setLocalizacao('');
        setDispositivoSelecionado('');
        setEstufaSelecionada('');
      }
    } catch (err) {
      console.log(err, 'falha ao enviar');
    }
  }

  return (
    <div>
      <Card>
        <CardHeader>
          <strong>Cadastro de bancada</strong>
        </CardHeader>
        <CardBody>
          <Form onSubmit={handleSubmit}>
            <FormGroup row className="my-0">
              <Col xs="6">
                <FormGroup>
                  <Label htmlFor="select">Estufa</Label>
                  <Input type="select" name="select" id="select" value={estufaSelecionada} onChange={({ target: { value } }) => { setEstufaSelecionada(value) }}>
                    <option value="0">Selecione uma opção</option>
                    {estufas?.map((item) => (<option key={item.idEstufa} value={item.idEstufa}>{item.nome}</option>))}
                  </Input>
                  <FormText className="help-block">Escolha a estufa que deseja vincular à sua bancada</FormText>
                </FormGroup>
              </Col>
              <Col xs="6">
                <FormGroup>
                  <Label htmlFor="select">Dispositivo</Label>
                  <Input type="select" name="select" id="select" value={dispositivoSelecionado} onChange={({ target: { value } }) => { setDispositivoSelecionado(value) }}>
                    <option value="0">Selecione uma opção</option>
                    {dispositivos?.map((item) => (<option key={item.idDispositivo} value={item.idDispositivo}>{item.nome}</option>))}
                  </Input>
                  <FormText className="help-block">Escolha o dispositivo que deseja vincular à sua bancada</FormText>
                </FormGroup>
              </Col>
            </FormGroup>
            <FormGroup row className="my-0">
              <Col xs="6">
                <FormGroup>
                  <Label htmlFor="nf-name">Nome</Label>
                  <Input type="text" id="nf-name" name="nf-name" placeholder="Ex: Bancada-01" value={nome} onChange={({ target: { value } }) => setNome(value)} />
                  <FormText className="help-block">Insira o nome da bancada</FormText>
                </FormGroup>
              </Col>
              <Col xs="6">
                <FormGroup>
                  <Label htmlFor="nf-location">Localização</Label>
                  <Input type="text" id="nf-location" name="nf-location" placeholder="Ex: Setor A6" value={localizacao} onChange={({ target: { value } }) => setLocalizacao(value)} />
                  <FormText className="help-block">Insira a localização da sua bancada.</FormText>
                </FormGroup>
              </Col>
            </FormGroup>
            <Button size="sm" color="primary">CADASTRAR</Button>
          </Form>
        </CardBody>
      </Card>
    </div>
  );
}

export default CadastroBancada;
