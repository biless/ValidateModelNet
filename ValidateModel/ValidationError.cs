namespace ValidateModel
{
    /// <summary>
    ///  模型验证错误类
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        ///  错误语言
        /// </summary>
        public string Language { get; set; }
        
        /// <summary>
        ///  字段名
        /// </summary>
        public string FieldName { get; set; }
        
        /// <summary>
        ///  字段错误信息
        /// </summary>
        public string FieldError { get; set; }
    }
}