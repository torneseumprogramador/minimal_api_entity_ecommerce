namespace Cairo.ModelViews;

public struct RetornoPaginadoView<T>
{
    public int TotalRegistros { get; set; }
    public int PaginaCorrente { get; set; }
    public int TotalPorPagina { get; set; }
    public List<T> Registros { get; set; }
}
