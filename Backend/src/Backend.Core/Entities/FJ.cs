using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Entities
{
    public enum State
    {
        New = 0, //新建项目
        UnProtocoled = 1, //未签订协议  finished

        Protocoled = 2, //已经提交资料签订了协议，未缴费

        Exploring = 3, //已缴费，勘探中

        UnDig = 4, // 勘探完成，不转考古 finish

        Diging = 5, // 勘探完成，转考古

        Diged = 6,// 考古发掘完成 finish
    }

    public class FJ : Entity, IHasCreationTime
    {
        [Required]
        public State State { get; set; } = State.New;

        #region 状态： New

        [Required]
        public string Name { get; set; } //项目名称
        [Required]
        public string RegionCode { get; set; } //所在区域  pac
        [Required]
        public string RegionName { get; set; }  //所在区域
        [Required]
        public string RegionIndex { get; set; }  // 所在区域  前端要index
        public string LocationDetail { get; set; }  // 详细位置
        public RequestCompany RequestCompany { get; set; } //委托单位

        public string ProjPropertyName { get; set; }  // 项目性质
        public int ProjPropertyIndex { get; set; }  //  项目性质 前端要index
        public string LandPropertyName { get; set; }  // 用地性质
        public int LandPropertyIndex { get; set; } //用地性质 前端要index

        #endregion


        #region 状态： Protocoled 或 UnProtocoled

        public DateTime? DocumentSubmitDate { get; set; } // 委托资料提交时间
        public DateTime? DocumentReviewCompletedDate { get; set; } // 委托资料审核完成时间
        public DateTime? ProtocoledDate { get; set; } // 签订协议时间

        public string ProtocolNumber { get; set; } // 协议编号
        public DateTime? ProtocolSendDate { get; set; } // 签订派出时间
        public string ProtocolSendDepartment { get; set; } // 签订派出部门


        //如果不签协议 UnProtocoled
        public string UnProtocoledReason { get; set; } // 未签订协议原因  UnProtocoled only
        public int? UnProtocoledReasonIndex { get; set; } // 未签订协议原因 前端index

        #endregion


        #region    Exploring   UnDig   Explored 

        public DateTime? ExplorePaidDate { get; set; } // 勘探缴费时间
        //Exploring

        public string ExploreSituation { get; set; } // 项目现场文勘条件
        public DateTime? ExploreStartDate { get; set; } // 勘探开始时间
        public DateTime? ExploreEndDate { get; set; } // 勘探结束时间
        // UnDig 不发掘 finish


        public string Situation { get; set; }
        public string EstimateArea { get; set; } // 预计发掘面积 平方米
        public int? EstimateAreaIndex { get; set; } // 预计发掘面积 平方米 前端index
        public string EstimateTimespan { get; set; } // 预计发掘周期
                                                     // Explored 要发掘

        #endregion


        #region Diging  Diged 

        public string LetterDateBeforeDig { get; set; } // 发掘前期函告时间

        public string[] ImpactSituationItems { get; set; } // 发掘前期项目现场影响考古入场的实际情况
        public DateTime? DigProtocoledDate { get; set; } // 发掘协议签订时间

        public DateTime? DigPaidDate { get; set; } // 发掘费用缴纳时间

        public DateTime? DigStartDate { get; set; } // 发掘入场时间

        public DateTime? DigEndDate { get; set; } // 发掘结束时间

        public string StageReport { get; set; } // 发掘阶段性成果报告

        #endregion


        #region Repost

        public DateTime? HandoverData { get; set; } // 现场移交出具手续时间

        public DateTime? WorkInfoPublishDate { get; set; } // 出具《工作信息表》时间

        public DateTime? BusinessAdvicePublishDate { get; set; } // 出具《业务已经书》时间

        public DateTime? FinishNoticePublishDate { get; set; } // 出具《完毕通知书》时间


        #endregion




        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;


        public static string StateName(State state)
        {
            switch (state)
            {
                case State.New:
                    return "资料提交";

                case State.UnProtocoled:
                    return "协议未签订";

                case State.Protocoled:
                    return "勘探中";

                case State.Exploring:
                    return "勘探中";

                case State.UnDig:
                    return "不考古发掘";

                case State.Diging:
                    return "发掘中";

                case State.Diged:
                    return "发掘结束";
                default:
                    break;
            }
            return "状态错误";
        }
    }
}
