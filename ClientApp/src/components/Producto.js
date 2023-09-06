import React, { Fragment, useEffect, useState } from "react";
import { Card } from "primereact/card";
import { Link, useLocation } from "react-router-dom";
import { Button } from "primereact/button";
import deleteProducto from "../web/deleteService";

const ProductFooter = ({ idProducto = 0 }) => {
  const handleDelete = () => {
    deleteProducto(idProducto)
      .then((res) => console.log())
      .catch((res) => console.error(res));
  };
  return (
    <Fragment>
      <Link to="/">
        <div className="flex flex-row w-full align-items-end">
          <Button label="Eliminar" severity="danger" onClick={handleDelete} />
        </div>
      </Link>
    </Fragment>
  );
};

export default function Producto() {
  const [ready, setReady] = useState(false);
  const [producto, setProducto] = useState(null);
  let { state } = useLocation();

  useEffect(() => {
    if (producto === null) {
      setReady(true);
      setProducto(state.producto);
    }
  }, [producto, state]);

  return (
    <Card
      className="flex flex-wrap justify-content-center min-w-min max-w-full"
      footer={ready ? <ProductFooter idProducto={producto.id} /> : null}
    >
      {ready ? (
        Object.keys(producto).map((key, index) => (
          <div key={index} className="flex flex-row w-full gap-2">
            <strong>{key}:</strong>
            <span>{producto[key]}</span>
          </div>
        ))
      ) : (
        <b>Not ready</b>
      )}
    </Card>
  );
}
