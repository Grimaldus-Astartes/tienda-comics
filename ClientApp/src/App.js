import React, { Component } from 'react';
import { Route, Routes, Link } from 'react-router-dom';

import AppRoutes from './AppRoutes';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <div className="flex flex-column h-full justify-content-center align-items-center">
                <nav className='flex flex-row w-full'>
                    <Link to="/form">
                    <label className='pi pi-plus'>New</label>
                    </Link>
                </nav>
                <Routes>
                    {AppRoutes.map((route, index) => {
                        const { element, ...rest } = route;
                        return <Route key={index} {...rest} element={element} />;
                    })}
                </Routes>
            </div>
        );
    }
}
