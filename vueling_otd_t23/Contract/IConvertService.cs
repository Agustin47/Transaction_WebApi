
namespace Contract
{

    using RequestResponse;

    public interface IConvertService
    {

        /// <summary>
        /// Rate convert.
        /// </summary>
        /// <param name="rate">Rate to convert</param>
        /// <returns>Rate converted</returns>
        ConvertFromResponse ConvertFrom(ConvertFromRequest request);

    }
}
