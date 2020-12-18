using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Entities
{
    public class FJ2 : Entity, IHasCreationTime
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        public string ProjName { get; set; }

        /// <summary>
        /// 项目单位
        /// </summary>
        public string ProjCompany { get; set; }

        /// <summary>
        /// 所在区域  pac
        /// </summary>
        public string RegionCode { get; set; }
        /// <summary>
        /// 所在区域
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 所在区域  前端要index
        /// </summary>
        public string RegionIndex { get; set; }

        /// <summary>
        /// 详细位置
        /// </summary>
        public string LocationDetail { get; set; }

        /// <summary>
        /// 土地用地性质
        /// </summary>
        public string LandPropertyName { get; set; }
        /// <summary>
        /// 土地用地性质 前端要index
        /// </summary>
        public int? LandPropertyIndex { get; set; }

        /// <summary>
        /// 是否重点项目
        /// </summary>
        public bool MajorProj { get; set; } = false;

        /// <summary>
        /// 资料提交时间
        /// </summary>
        public DateTime? DocumentSubmitDate { get; set; }

        /// <summary>
        /// 纸质资料审核完成时间
        /// </summary>
        public DateTime? PaperDocumentReviewCompletionDate { get; set; }

        /// <summary>
        /// 现场核实完成时间
        /// </summary>
        public DateTime? OnSiteVerificationCompletionDate { get; set; }





        /// <summary>
        /// 是否具备考古调查勘探条件
        /// </summary>
        public bool IfSurvey { get; set; } = false;

        /// <summary>
        /// 不具备考古调查勘探条件原因
        /// </summary>
        public string[] NotSurveyReasons { get; set; }

        /// <summary>
        /// 考古工作方式
        /// </summary>
        public string SurveyWorkType { get; set; }

        /// <summary>
        /// 是否签订文勘协议
        /// </summary>
        public bool IfSignSurveyAgreement { get; set; } = false;

        /// <summary>
        /// 市考古队向项目单位发送协议时间（调查方式不填）
        /// </summary>
        public DateTime? SendSurveyAgreementDate { get; set; }

        /// <summary>
        /// 项目单位反馈盖章协议时间（调查方式不填）
        /// </summary>
        public DateTime? ReplyStampedSurveyAgreementDate { get; set; }

        /// <summary>
        /// 正式协议签订时间（调查方式不填）
        /// </summary>
        public DateTime? SignSurveyAgreementDate { get; set; }

        /// <summary>
        /// 协议编号（调查方式不填）
        /// </summary>
        public string SurveyAgreementNumber { get; set; }

        /// <summary>
        /// 工作任务派出时间
        /// </summary>
        public DateTime? TaskExclusionDate { get; set; }

        /// <summary>
        /// 实施部门
        /// </summary>
        public string SurveyDepartment { get; set; }






        /// <summary>
        /// 与项目单位现场沟通时间
        /// </summary>
        public DateTime? CommunicateWithProjCompanyDate { get; set; }

        /// <summary>
        /// 是否具备考古勘探入场条件
        /// </summary>
        public bool IfHaveTheConditionsForSurvey { get; set; } = false;

        /// <summary>
        /// 不具备考古勘探入场条件原因
        /// </summary>
        public string[] NotHaveTheConditionsForSurveyReasons { get; set; }



        /// <summary>
        /// 勘探正式入场时间
        /// </summary>
        public DateTime? SurveyEnterDate { get; set; }

        /// 勘探结束时间
        /// </summary>
        public DateTime? SurveyEndDate { get; set; }

        /// <summary>
        /// 是否转入考古发掘
        /// </summary>
        public bool IfExcavation { get; set; } = false;


        /// <summary>
        /// 遗存发现基本情况
        /// </summary>
        public string[] RemainsInfo { get; set; }

        /// <summary>
        /// 预计发掘面积（单位：200平方米）
        /// </summary>
        public string EstimateExcavateArea { get; set; }

        /// <summary>
        /// 预计发掘周期
        /// </summary>
        public string EstimateExcavateDuration { get; set; }

        /// <summary>
        /// 工程项目名称
        /// </summary>
        public string ExcavationProjName { get; set; }

        /// <summary>
        /// 是否具备考古发掘入场条件（三选一）
        /// </summary>
        public string IfHaveTheConditionsForExcavation { get; set; }

        /// <summary>
        /// 不具备入场条件原因
        /// </summary>
        public string[] NotHaveTheConditionsForExcavationReasons { get; set; }

        /// <summary>
        /// 部分具备发掘入场条件面积
        /// </summary>
        public string PartHaveTheConditionsForExcavationArea { get; set; }

        /// <summary>
        /// 是否启动考古发掘（三选一）
        /// </summary>
        public string IfStartExcavation { get; set; }

        /// <summary>
        /// 考古发掘入场时间
        /// </summary>
        public DateTime? ExcavationEnterDate { get; set; }

        /// <summary>
        /// 部分考古发掘结束时间
        /// </summary>
        public DateTime? PartExcavationEndDate { get; set; }

        /// <summary>
        /// 全部考古发掘结束时间
        /// </summary>
        public DateTime? ExcavationEndDate { get; set; }

        /// <summary>
        /// 考古发掘协议签订时间
        /// </summary>
        public DateTime? SignExcavationAgreementDate { get; set; }



        /// <summary>
        /// 是否缴纳勘探费
        /// </summary>
        public string IfPaySurveyFee { get; set; }

        /// <summary>
        /// 勘探费缴纳时间
        /// </summary>
        public DateTime? PaySurveyFeeDate { get; set; }

        /// <summary>
        /// 考古发掘费缴纳时间
        /// </summary>
        public DateTime? PayExcavationFeeDate { get; set; }

        /// <summary>
        /// 工作信息表出具时间
        /// </summary>
        public DateTime? WorkInfoDocumentIssuanceDate { get; set; }



        /// <summary>
        /// 完毕业务意见书-出具时间
        /// </summary>
        public DateTime? WorkFinishInfoDocumentIssuanceDate { get; set; }

        /// <summary>
        /// 完毕业务意见书-通知项目单位领取时间
        /// </summary>
        public DateTime? NoticeOfReceiveWorkFinishInfoDocumentDate { get; set; }

        /// <summary>
        /// 完毕业务意见书-是否领取
        /// </summary>
        public bool ReceivedWorkFinishInfoDocument { get; set; } = false;



        /// <summary>
        /// 完毕通知书-出具时间
        /// </summary>
        public DateTime? FinishDocumentIssuanceDate { get; set; }

        /// <summary>
        /// 完毕通知书-通知项目单位领取时间
        /// </summary>
        public DateTime? NoticeOfReceiveFinishDocumentDate { get; set; }

        /// <summary>
        /// 完毕通知书-是否领取
        /// </summary>
        public bool ReceivedFinishDocument { get; set; } = false;


        /// <summary>
        /// 项目考古工作完成
        /// </summary>
        public bool AllFinish { get; set; } = false;



        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
