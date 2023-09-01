import React, { useState } from "react";

import { InputText } from "primereact/inputtext";
import { InputNumber } from "primereact/inputnumber";
import { Dropdown } from "primereact/dropdown";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { Message } from "primereact/message";

import postAProduct from "../web/postService";

export default function Form({ title = "sample text" }) {
  const [formState, setForm] = useState(initForm);
  const [submitted, setSubmitted] = useState();

  const handleChange = (e) => {
    const { name: propertieName } = e.target;
    const { value } = e.target;
    setForm({
      ...formState,
      [propertieName]: value,
    });
  };

  const handleNumberChange = (e) => {
    const { name: propertieName } = e.originalEvent.target;
    const { value } = e;
    setForm({
      ...formState,
      [propertieName]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    let submit = true;

    for (const [key, value] of Object.entries(formState)) {
      if (!value) {
        setSubmitted("Los valores no pueden estar vacios");
        submit = false;
      }
    }

    if (submit)
      postAProduct(formState)
        .then(() => setSubmitted("Se envio correctamente"))
        .catch(() => setSubmitted("Hubo un error al enviar"));
  };

  return (
    <Card className="flex flex-column min-w-min max-w-full w-10" title={title}>
      <form style={{ all: "inherit" }}>
        <div className="flex flex-row gap-2 w-full">
          <div className="flex flex-column gap-2 w-6">
            <label htmlFor="nombre-producto">Nombre</label>
            <InputText
              id="nombre-producto"
              name="nombre"
              value={formState.nombre}
              onChange={handleChange}
            />
          </div>
          <div className="flex flex-column gap-2 w-6">
            <label htmlFor="genero-producto">Genero</label>
            <InputText
              id="genero-producto"
              name="genero"
              value={formState.genero}
              onChange={handleChange}
            />
          </div>
        </div>
        <div className="flex flex-row gap-2 w-full">
          <div className="flex flex-column gap-2 w-6">
            <label htmlFor="fabricante-producto">Fabricante</label>
            <InputText
              id="fabricante-producto"
              name="fabricante"
              value={formState.fabricante}
              onChange={handleChange}
            />
          </div>
          <div className="flex flex-column gap-2 w-6">
            <label htmlFor="proveedor-producto">Proveedor</label>
            <InputText
              id="proveedor-producto"
              name="proveedor"
              value={formState.proveedor}
              onChange={handleChange}
            />
          </div>
        </div>
        <div className="flex flex-row gap-2 w-full">
          <div className="flex flex-column gap-2 w-6">
            <label htmlFor="existencia-producto">Existencia</label>
            <InputNumber
              id="existencia-producto"
              name="existencia"
              value={formState.existencia}
              onChange={handleNumberChange}
            />
          </div>
          <div className="flex flex-column gap-2 w-6">
            <label htmlFor="precio-producto">Precio</label>
            <InputNumber
              id="precio-producto"
              name="precio"
              value={formState.precio}
              onChange={handleNumberChange}
            />
          </div>
        </div>
        <div className="flex flex-column w-3">
          <label htmlFor="tipo-producto">Tipo</label>
          <Dropdown
            id="tipo-producto"
            name="tipo"
            options={tipos}
            placeholder="Selecciona el tipo"
            optionLabel="name"
            optionValue="name"
            onChange={handleChange}
            value={formState.tipo}
          />
        </div>
        <div className="flex flex-column w-full">
          <div className="w-3">
            <Button
              label="Enviar"
              icon="pi pi-save"
              className="align-items-end"
              onClick={handleSubmit}
            />
          </div>
        </div>
        <Message severity="info" text={submitted} />
      </form>
    </Card>
  );
}

const initForm = {
  nombre: "",
  genero: "",
  fabricante: "",
  proveedor: "",
  existencia: 0,
  precio: 0,
  tipo: "",
};

const tipos = [
  { name: "Comic" },
  { name: "Pelicula" },
  { name: "Video Juego" },
];
