let colores: string[] = ['Rosa', 'Morado', 'Azul'];

interface Articulo {
    nombre: string,
    existencia: number,
    colores: string[],
    marca ?: string
}

const refaccion: Articulo = {
    nombre: 'filtro',
    existencia: 50,
    colores: ['Blanco', 'Negro'],
    // marca: 'Marca'
}

refaccion.marca = 'LTN'

console.log(refaccion);

