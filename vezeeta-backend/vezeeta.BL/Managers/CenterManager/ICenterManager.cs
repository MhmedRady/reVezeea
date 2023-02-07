using vezeeta.BL.DTOs.Center;

namespace vezeeta.BL.Managers.CenterManger;

public interface ICenterManager : IGenericManager<CenterDTO>
{
    public IEnumerable<CenterReadDto>? LoadData();
}