using Abp.Application.Services.Dto;
using Backend.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Dtos
{
    public class FJOutput : EntityDto
    {
        public State State { get; set; }
        public string StateName {
            get {
                return FJ.StateName(State);
            }
        }

        public string Name { get; set; } //项目名称
        public string RegionCode { get; set; } //所在区域  pac
        public string RegionName { get; set; }  //所在区域
        public string RegionIndex { get; set; }  // 所在区域  前端要index
        public string LocationDetail { get; set; }  // 详细位置

        public string ProjPropertyName { get; set; }  // 项目性质
        public int ProjPropertyIndex { get; set; }  //  项目性质 前端要index
        public string LandPropertyName { get; set; }  // 用地性质
        public int LandPropertyIndex { get; set; } //用地性质 前端要index




        public DateTime? DocumentSubmitDate { get; set; } //委托资料提交时间
        public DateTime? DocumentReviewCompletedDate { get; set; } //委托资料审核完成时间
        public DateTime? ProtocoledDate { get; set; } //签订协议时间

        //如果不签协议 UnProtocoled
        public string UnProtocoledReason { get; set; } //未签订协议原因  UnProtocoled only
        public int? UnProtocoledReasonIndex { get; set; } //未签订协议原因 前端index




        public DateTime? ExplorePaidDate { get; set; } // 勘探缴费时间
        //Exploring

        public DateTime? ExploreStartDate { get; set; } // 勘探开始时间
        public DateTime? ExploreEndDate { get; set; } // 勘探结束时间
        // UnDig 不发掘 finish


        public string Situation { get; set; }
        public double? EstimateArea { get; set; } // 预计发掘面积 平方米
        public DateTime? EstimateFinishDate { get; set; } // 预计发掘结束时间  
                                                          // Explored 要发掘




        public string LetterDateBeforeDig { get; set; } // 发掘前期函告时间

        public string[] ImpactSituationItems { get; set; } // 发掘前期项目现场影响考古入场的实际情况
        public DateTime? DigProtocoledDate { get; set; } // 发掘协议签订时间

        public DateTime? DigPaidDate { get; set; } // 发掘费用缴纳时间

        public DateTime? DigStartDate { get; set; } // 发掘入场时间

        public DateTime? DigEndDate { get; set; } // 发掘结束时间

        public string StageReport { get; set; } // 发掘阶段性成果报告

        public DateTime? WorkInfoPublishDate { get; set; } // 出具《工作信息表》时间

        public DateTime? BusinessAdvicePublishDate { get; set; } // 出具《业务已经书》时间

        public DateTime? FinishNoticePublishDate { get; set; } // 出具《完毕通知书》时间




        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreationTimeStr {
            get {
                return CreationTime.Year + "-" +
                    CreationTime.Month.ToString("00") + "-" +
                    CreationTime.Day.ToString("00") + " " +
                    CreationTime.Hour.ToString("00") + ":" +
                    CreationTime.Minute.ToString("00") + ":" +
                    CreationTime.Second.ToString("00");
            }
        }
    }
}
